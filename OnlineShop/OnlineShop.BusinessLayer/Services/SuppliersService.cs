using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;
using Microsoft.Data.SqlClient;
using OnlineShop.BusinessLayer.DTOs;

namespace OnlineShop.BusinessLayer.Services
{
    public class SuppliersService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Supplier> commonEntityService = new();
        private ActivityLogService logService = new ActivityLogService();
        private List<Supplier> suppliers = new List<Supplier>();
        private DapperContext dapperContext = new();

        public async Task<Supplier> CreateSupplier(string name, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = await connection.QueryAsync<Supplier>("CreateSupplier", new { SupplierName = name, SupplierEDRPOU = code });

                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // create log record
                Task.Run(() => logService.OutputLog(log));
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            }
        }


        public async Task<GetSupplierDto> GetSupplierByID(int id, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var suppliers = await connection.QueryAsync<Supplier>("GetSupplierByID", new { SupplierID = id });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                Task.Run(() => logService.OutputLog(log));
                var supplier = suppliers.FirstOrDefault();

                var getSupplierDto = new GetSupplierDto
                {
                    SupplierEDRPOU = supplier.SupplierEDRPOU,
                    SupplierID = supplier.SupplierID,
                    SupplierName = supplier.SupplierName
                };

                return getSupplierDto;
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<Supplier> GetSupplierByName(string name, string connectionStr)

        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var suppliers = await connection.QueryAsync<Supplier>("GetSupplierByName", new { SupplierName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                Task.Run(() => logService.OutputLog(log));
                return suppliers.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public async Task<Supplier> GetSupplierByCode(string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = await connection.QueryAsync<Supplier>("GetSupplierByCode", new { SupplierEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                Task.Run(() => logService.OutputLog(log));
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<Supplier> UpdateSupplierNameByID(int id, string name, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = await connection.QueryAsync<Supplier>("UpdateSupplierName", new { SupplierID = id, SupplierName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                Task.Run(() => logService.OutputLog(log));
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<Supplier> UpdateSupplierCodeByID(int id, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = await connection.QueryAsync<Supplier>("UpdateSupplierEDRPOU", new { SupplierID = id, SupplierEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                Task.Run(() => logService.OutputLog(log));
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }
        public async Task<string> DeleteSupplierByID(int supplierID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var result = await connection.ExecuteAsync("DeleteSupplierByID", new { SupplierID = supplierID });

                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.DELETED, commonEntityService.GetListType()); // create log record
                Task.Run(() => logService.OutputLog(log));

                if (result > 0)
                {
                    return "The supplier has been successfully deleted";
                }
                else
                {
                    return "Failed to remove supplier. This ID may not exist.";
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

        public async Task<List<Supplier>> GetAllSuppliers(string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var sql = "SELECT * FROM Supplier";
            var suppliers = await connection.QueryAsync<Supplier>(sql);
            return suppliers.ToList();
        }


        public async Task OutputSuppliers(List<Supplier> suppliers)
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(suppliers), commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
            Task.Run(() => logService.OutputLog(log));
        }
    }
}