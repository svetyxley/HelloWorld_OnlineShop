using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;
using System.Linq;

namespace OnlineShop.BusinessLayer.Services
{
    public class ManufacturesService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator idGenerator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Manufacturer> commonEntityService = new();

        private DapperContext dapperContext = new();

        ActivityLogService logService = new ActivityLogService();

        private List<Manufacturer> manufacturers = new List<Manufacturer>();
        public Manufacturer CreateManufacturer()
        {
            int manufacturerID = idGenerator.InputID(manufacturers);
            string manufacturerName = inputManager.InputName(inputValidator, commonEntityService.GetListType());
            string manufacturerEDRPOU = inputManager.InputEDRPU(inputValidator, commonEntityService.GetListType());
            return new Manufacturer(manufacturerID, manufacturerName, manufacturerEDRPOU);
        }

        public void AddToManufacturers()
        {
            manufacturers.Add(CreateManufacturer());
            outputManager.OutputToConsole(NotificationConstants.ADDED, commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
        }

        public  Manufacturer GetManufacturerByID(int id, string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var manufacturer = connection.Query<Manufacturer>("GetManufacturerById", new { ManufacturerID = id });
            if (manufacturer.Count() == 0)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
            return manufacturer.FirstOrDefault();
        }

        public Manufacturer GetManufacturerByName(string  manufacturerName)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturers => manufacturers.ManufacturerName == manufacturerName);

            if (manufacturer == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
            return manufacturer;
        }

        public Manufacturer UpdateManufacturer(int manufacturerID)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturer => manufacturer.ManufacturerID == manufacturerID);
            if (manufacturer == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return manufacturer;
        }

        public void DeleteManufacturerByID(int manufacturerID)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturer => manufacturer.ManufacturerID == manufacturerID);
            if (manufacturer != null)
            {
                manufacturers.Remove(manufacturer);
                outputManager.OutputToConsole(NotificationConstants.DELETED, commonEntityService.GetListType());
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.DELETED, commonEntityService.GetListType()); // cteate log record
                logService.OutputLog(log);// output result to log
            }
            else
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
        }

        public void OutputManufacturers()
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(manufacturers), commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
        }
    }
}
