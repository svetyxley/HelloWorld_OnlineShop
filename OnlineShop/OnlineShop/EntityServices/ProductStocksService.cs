using OnlineShop.Constants;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
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

        private List<ProductStocks> productStocks = new List<ProductStocks>()
        {
            new ProductStocks(10),
        };
        public ProductStocks CreateProduct()
        {
            var _product = productsService.GetProductByID();
            int productAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
            return new ProductStocks(_product, productAmount);
        }
        public void AddProduct()
        {
            productStocks.Add(CreateProduct());
            outputManager.Write(NotificationConstants.ADDED, commonEntityService.GetListType());
        }
        public ProductStocks BuyProducts()
        {
            
        }
    }
}