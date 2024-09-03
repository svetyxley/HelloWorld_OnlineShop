using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.EntityServices;
using Dapper;

namespace OnlineShop.BusinessLayer.Services
{
    public class ProductStocksService
    {
        private InputManager inputManager = new();
        private OutputManager outputManager = new();
        private IDGenerator idGenerator = new();
        private InputValidator inputValidator = new();
        private CommonEntityService<OrderSupply> commonEntityService = new();
        private ProductsService productsService = new();
        private OrderSupplyService orderSupplyService = new();
        private List<ProductStocks> productStocksList = new List<ProductStocks>();
        private DapperContext dapperContext = new();

        public async Task<ProductStocks> CreateProductOnStock(int productID, int productAmount, int stockItemID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var product = await connection.QueryAsync<ProductStocks>("CreateProductOnStock", new { ProductName = productsService.GetProductByID(productID, connectionStr),
                ProductAmount = productAmount, StockItemID = stockItemID });
                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        //public async Task AddProduct(Product _product, int productAmount)
        //{
        //    productStocksList.Add(await CreateProduct(_product, productAmount));
        //    outputManager.OutputToConsole(NotificationConstants.PRODUCT_IS_SUCESSFULLY_ADDED, commonEntityService.GetListType());
        //}
        public async Task<int> GetAmountByStockItemID(int _stockItemID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var stock = await connection.QueryAsync<ProductStocks>("GetAmountByStockItemID", new { StockItemID = _stockItemID });
                return stock.FirstOrDefault().ProductAmount;
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task<ProductStocks> UpdateOfAmount(int productID, int productAmount, int stockItemID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var amount = await connection.QueryAsync<ProductStocks>("UpdateOfAmount", new { product = productsService.GetProductByID(productID, connectionStr),
                ProductAmount = productAmount, StockItemID = stockItemID });
                return amount.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task BuyProducts(int productID, int productAmount, int stockItemID, string connectionStr)
        {
            try
            {
                int amountOnStock = await GetAmountByStockItemID(stockItemID, connectionStr);
                if (productAmount <= amountOnStock)
                {
                    amountOnStock -= productAmount;
                    var productStock = UpdateOfAmount(productID, amountOnStock, stockItemID, connectionStr);
                }
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        //public async Task ShowProductStock(ProductStocks productStock)
        //{
        //    try
        //    {
        //        if (productStock.IsInStock())
        //        {
        //            Console.WriteLine(productStock.GetStockSummary());
        //        }
        //        else
        //        {
        //            Console.WriteLine("Product is out of stock.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        outputManager.OutputException(ex);
        //        throw;
        //    }
        //}
    }
}