using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.EntityServices;

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

        private List<ProductStocks> productStocksList = new List<ProductStocks>()
        {
            new ProductStocks(10),
        };
        public async Task<ProductStocks> CreateProduct(Product _product, int productAmount)
        {
            _product = await productsService.GetProductByID(1, "connectionStr");
            productAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
            return new ProductStocks(_product, productAmount);
        }
        public async Task AddProduct(Product _product, int productAmount)
        {
            productStocksList.Add(await CreateProduct(_product, productAmount));
            outputManager.OutputToConsole(NotificationConstants.PRODUCT_IS_SUCESSFULLY_ADDED, commonEntityService.GetListType());
        }
        public int GetAmountByID(int productID, string connectionStr)
        {
            var product = productsService.GetProductByID(productID, connectionStr);
            if (product != null)
            {
                var productStock = productStocksList.FirstOrDefault(ps => ps.product != null && ps.product.ProductID == productID);
                if (productStock != null)
                {
                    return productStock.ProductAmount;
                }
            }
            return 0;
        }
        public ProductStocks UpdateOfAmount(int productID, int productAmount, string connectionStr)
        {
            var product = productsService.GetProductByID(productID, connectionStr);
            if (product != null)
            {
                var productStock = productStocksList.FirstOrDefault(ps => ps.product != null && ps.product.ProductID == productID);
                if (productStock != null)
                {
                    productStock.ProductAmount = productAmount;
                    return productStock;
                }
            }
            return null;
        }
        public ProductStocks BuyProducts(int productID, int productAmount, string connectionStr)
        {
            int AmountOnStock = GetAmountByID(productID, connectionStr);
            if (productAmount <= AmountOnStock)
            {
                AmountOnStock-=productAmount;
                var productStock = UpdateOfAmount(productID, AmountOnStock, connectionStr);
                return productStock;
            }
            return null;
        }
    }
}