using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.EntityServices;

namespace OnlineShop.BusinessLayer.Services
{
    public class OrderSupplyService
    {
        private InputManager inputManager = new();
        private OutputManager outputManager = new();
        private IDGenerator idGenerator = new();
        private InputValidator inputValidator = new();
        private CommonEntityService<OrderSupply> commonEntityService = new();
        private SuppliersService suppliersService = new();
        private ProductsService productsService = new();
        private EmployeeService employeeService = new();
        private List<OrderSupply> orderSupply = new List<OrderSupply>();
        private DapperContext dapperContext = new();

        public async Task<OrderSupply> MakeOrderOfSupply(int supplierID, int productID, int productAmount, DateTime orderTime, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supply = await connection.QueryAsync<OrderSupply>("MakeOrderOfSupply", new {  
                    _supplier = suppliersService.GetSupplierByID(supplierID, connectionStr),
                    _product = productsService.GetProductByID(productID, connectionStr),
                    ProductAmount = productAmount,
                    OrderTime = orderTime,
                    _employee = employeeService.GetEmployeeByID()
                });
                return supply.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task<OrderSupply> GetSupplyOrderByID(int supplyID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supply = await connection.QueryAsync<OrderSupply>("GetSupplyOrderByID", new { OrderSupplyID = supplyID });
                return supply.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        //public async Task<int> GetAmount(int supplyAmount)
        //{
        //    //var supplyAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
        //    try
        //    {
        //        var supply = orderSupply.FirstOrDefault(orderSupply => orderSupply.ProductAmount == supplyAmount);
        //        if (supply == null)
        //        {
        //            outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
        //        }
        //        else
        //        {
        //            outputManager.OutputToConsole(supply.ToString(), commonEntityService.GetListType());
        //        }
        //        return supplyAmount;
        //    }
        //    catch (Exception ex)
        //    {
        //        outputManager.OutputException(ex);
        //        throw;
        //    }
        //}
        public async Task<List<OrderSupply>> OutputSupplyOrders(string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var sql = $"select * FROM OrderSupply";
                var supplies = await connection.QueryAsync<OrderSupply>(sql);
                return supplies.AsList();
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
    }
}