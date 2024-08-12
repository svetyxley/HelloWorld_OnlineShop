﻿using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;
using Microsoft.Data.SqlClient;


namespace OnlineShop.BusinessLayer.Services
{
    public class ProductsService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Product> commonEntityService = new();
        private ActivityLogService logService = new ActivityLogService();
        private List<Product> products = new List<Product>();
        private DapperContext dapperContext = new();

        //ProductName nvarchar(255),
        //ProductCategoryID int,
        //ManufacturerID int,
        //SupplierID int
        //ProductPrice decimal (10, 2),
        public Product CreateProduct(string name, int productCategoryID, int manufacturerID, int supplierID, double price, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = connection.Query<Product>("CreateProduct", new { ProductName = name, ProductCategoryID = productCategoryID, ManufacturerID = manufacturerID, SupplierID = supplierID,  ProductPrice = price });
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Product GetProductByID(int id, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = connection.Query<Product>("GetProductByID", new { ProductID = id });
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Product GetProductByName(string name, string connectionStr)


        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = connection.Query<Product>("GetProductByName", new { ProductName = name });
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Product UpdateProductName(int id, string name, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = connection.Query<Product>("UpdateProductName", new { ProductID = id, ProductName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Product UpdateProductCategory(int id, int category, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = connection.Query<Product>("UpdateProductCategory", new { ProductID = id, ProductCategoryID = category });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Product UpdateProductManufacturer(int id, int manufacturerID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = connection.Query<Product>("UpdateProductManufacturer", new { ProductID = id, ManufacturerID = manufacturerID });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Product UpdateProductSupplier(int id, int supplierID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = connection.Query<Product>("UpdateProductSupplier", new { ProductID = id, SupplierID = supplierID });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public Product UpdateProductPrice(int id, double price, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = connection.Query<Product>("UpdateProductPrice", new { ProductID = id, ProductPrice = price});
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public string DeleteProductByID(int id, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var result = connection.Execute("DeleteProductByID", new { ProductID = id });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.DELETED, commonEntityService.GetListType()); // create log record
                logService.OutputLog(log);// output result to log
                if (result > 0)
                {
                    return "The Product has been successfully deleted";
                }
                else
                {
                    return "Failed to remove Product. This ID may not exist.";
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

        public List<Product> GetAllProducts(string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var sql = $"select * FROM Product";
            var products = connection.Query<Product>(sql).AsList();
            return products;
        }

        public void OutputProducts(List<Product> products)
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(products), commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
            logService.OutputLog(log);// output result to log
        }

        public int GetProductsAmount()
        {
            return commonEntityService.ListAmount(products);
        }
    }
}