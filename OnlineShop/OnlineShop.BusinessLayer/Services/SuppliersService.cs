﻿using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;
using Microsoft.Data.SqlClient;

namespace OnlineShop.BusinessLayer.Services
{
    public class SuppliersService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Supplier> commonEntityService = new();
        private ActivityLogService logService = new ActivityLogService();
 //       private List<Supplier> suppliers = new List<Supplier>();
        private DapperContext dapperContext = new();


        public Supplier CreateSupplier(string name, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = connection.Query<Supplier>("CreateSupplier", new { SupplierName = name, SupplierEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Supplier GetSupplierByID(int id, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = connection.Query<Supplier>("GetSupplierByID", new { SupplierID = id });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Supplier GetSupplierByName(string name, string connectionStr)


        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = connection.Query<Supplier>("GetSupplierByName", new { SupplierName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public Supplier GetSupplierByCode(string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = connection.Query<Supplier>("GetSupplierByCode", new { SupplierEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Supplier UpdateSupplierNameByID(int id, string name, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = connection.Query<Supplier>("UpdateSupplierName", new { SupplierID = id, SupplierName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Supplier UpdateSupplierCodeByID(int id, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = connection.Query<Supplier>("UpdateSupplierEDRPOU", new { SupplierID = id, SupplierEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return supplier.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public string DeleteSupplierByID(int supplierID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var result = connection.Execute("DeleteSupplierByID", new { SupplierID = supplierID });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.DELETED, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
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

        public List<Supplier> GetAllSuppliers(string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var sql = $"select * FROM Supplier";
            var suppliers = connection.Query<Supplier>(sql).AsList();
            return suppliers;
        }

        public void OutputSuppliers(List<Supplier> suppliers)
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(suppliers), commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
            logService.OutputLog(log);// output result to log
        }
    }
}