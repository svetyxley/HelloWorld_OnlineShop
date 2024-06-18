using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Data.Entities;
using OnlineShop.Records;

namespace OnlineShop.BusinessLayer.Services
{
    public class SuppliersService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator idGenerator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Supplier> commonEntityService = new();
        ActivityLogService logService = new ActivityLogService();

        private List<Supplier> suppliers = new List<Supplier>()
        {
        new Supplier(1, "Supplier1", "SupplierEDRPOU1"),
        new Supplier(2, "Supplier2", "SupplierEDRPOU2"),
        new Supplier(3, "Supplier3", "SupplierEDRPOU3")
        };

        public Supplier CreateSupplier()
        {
            int supplierID = idGenerator.InputID(suppliers);
            string supplierName = inputManager.InputName(inputValidator, commonEntityService.GetListType());
            string supplierEDRPOU = inputManager.InputEDRPU(inputValidator, commonEntityService.GetListType());
            return new Supplier(supplierID, supplierName, supplierEDRPOU);
        }

        public void AddToSuppliers()
        {
            suppliers.Add(CreateSupplier());
            outputManager.OutputToConsole(NotificationConstants.ADDED, commonEntityService.GetListType()); // output result to consol
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
        }

        public Supplier GetSupplierByID()
        {
            var supplierID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
            return supplier;
        }

        //додати логику апдейту
        public Supplier UpdateSupplier(int supplierID)
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


        public void DeleteSupplierByID(int supplierID)
        {
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier != null)
            {
                suppliers.Remove(supplier);
                outputManager.OutputToConsole(NotificationConstants.DELETED, commonEntityService.GetListType());
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // cteate log record
                logService.OutputLog(log);// output result to log
            }
            else
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
        }

        public void OutputSuppliers()
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(suppliers), commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
        }
    }
}