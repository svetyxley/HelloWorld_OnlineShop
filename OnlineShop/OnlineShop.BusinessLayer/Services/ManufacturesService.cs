using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;
using Microsoft.Data.SqlClient;

namespace OnlineShop.BusinessLayer.Services
{
    public class ManufacturersService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Manufacturer> commonEntityService = new();
        private ActivityLogService logService = new ActivityLogService();
        private List<Manufacturer> manufacturers = new List<Manufacturer>();
        private DapperContext dapperContext = new();


        public Manufacturer CreateManufacturer(string name, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = connection.Query<Manufacturer>("CreateManufacturer", new { ManufacturerName = name, ManufacturerEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Manufacturer GetManufacturerByID(int id, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = connection.Query<Manufacturer>("GetManufacturerByID", new { ManufacturerID = id });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Manufacturer GetManufacturerByName(string name, string connectionStr)


        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = connection.Query<Manufacturer>("GetManufacturerByName", new { ManufacturerName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public Manufacturer GetManufacturerByCode(string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = connection.Query<Manufacturer>("GetManufacturerByCode", new { ManufacturerEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Manufacturer UpdateManufacturerNameByID(int id, string name, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = connection.Query<Manufacturer>("UpdateManufacturerName", new { ManufacturerID = id, ManufacturerName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Manufacturer UpdateManufacturerCodeByID(int id, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = connection.Query<Manufacturer>("UpdateManufacturerEDRPOU", new { ManufacturerID = id, ManufacturerEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public string DeleteManufacturerByID(int ManufacturerID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var result = connection.Execute("DeleteManufacturerByID", new { ManufacturerID = ManufacturerID });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.DELETED, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                if (result > 0)
                {
                    return "The Manufacturer has been successfully deleted";
                }
                else
                {
                    return "Failed to remove Manufacturer. This ID may not exist.";
                }
            }
            catch (SqlException ex)
            {
                return $"Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public List<Manufacturer> GetAllManufacturers(string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var sql = $"select * FROM Manufacturer";
            var manufacturers = connection.Query<Manufacturer>(sql).AsList();
            return manufacturers;
        }

        public void OutputManufacturers(List<Manufacturer> manufacturers)
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(manufacturers), commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
            logService.OutputLog(log);// output result to log
        }
    }
}