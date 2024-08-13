using System.Data;
using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;

namespace OnlineShop.BusinessLayer.Services
{
    public class SuppliersService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator idGenerator = new();
        private OutputManager outputManager;
        private CommonEntityService<Supplier> commonEntityService = new();
        ActivityLogService logService;

        private List<Supplier> suppliers = new List<Supplier>();

        private DapperContext dapperContext;

        public SuppliersService(DapperContext context, ActivityLogService service, OutputManager manager)
        {
            dapperContext = context;
            logService = service;
            outputManager = manager;

        }

        public async Task CreateSupplier(string name, string code, string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var supplier = connection.ExecuteAsync("CreateSupplier", new { SupplierName = name, SupplierEDRPOU = code });
        }

        public Supplier GetSupplierByID(int id, string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var supplier = connection.Query<Supplier>("GetSupplierByID", new { SupplierID = id });
            return supplier.FirstOrDefault();
        }

        //додати логику апдейту
        public Supplier UpdateSupplier(List<Supplier> suppliers, int supplierID)
        {
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
            return supplier;
        }


        public void DeleteSupplierByID(int supplierID, string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
                connection.Execute("DeleteSupplierByID", new { SupplierID = supplierID });
                outputManager.OutputToConsole(NotificationConstants.DELETED, commonEntityService.GetListType());
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // cteate log record
                logService.OutputLog(log);// output result to log
        }

        public List<Supplier> GetAllSupliers(string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var sql = $"select * FROM Supplier";
            var suppliers = connection.Query<Supplier>(sql).AsList();
            return suppliers;
        }

        public void OutputSuppliers(List<Supplier> suppliers)
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(suppliers), commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
        }
    }
}