using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;

namespace OnlineShop.BusinessLayer.Services
{
    public class ProductsService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator idGenerator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Product> commonEntityService = new();
        private ManufacturesService manufacturesService = new();
        private SuppliersService suppliersService = new(new DapperContext(), new ActivityLogService(), new OutputManager());
        ActivityLogService logService = new ActivityLogService();


        private List<Product> products = new List<Product>()
        {
            new Product(1, "Product1"),
            new Product(2, "Product2"),
            new Product(3, "Product3")
        };


        public Product CreateProduct()
        {
            int productId = idGenerator.InputID(products);
            string productName = inputManager.InputName(inputValidator, commonEntityService.GetListType());
            double productPrice = inputManager.InputPrice(inputValidator, commonEntityService.GetListType());
            return new Product();
            //new Product(productId, productName, manufacturesService.GetManufacturerByID(), suppliersService.GetSupplierByID(), productPrice);
        }
        public void AddToProducts()
        {
            products.Add(CreateProduct());
            outputManager.OutputToConsole(NotificationConstants.ADDED, commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
        }

        public Product GetProductByID()
        {
            var productID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var product = products.FirstOrDefault(products => products.ProductID == productID);
            if (product == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            else
            {
                outputManager.OutputToConsole(product.ToString(), commonEntityService.GetListType());
            }
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
            return product;
        }
        public Product UpdateProduct()
        {
            var productID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var product = products.FirstOrDefault(products => products.ProductID == productID);
            if (product == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
            return product;
        }

        public void DeleteProductByID()
        {
            var productID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var product = products.FirstOrDefault(product => product.ProductID == productID);
            if (product != null)
            {
                products.Remove(product);
                outputManager.OutputToConsole(NotificationConstants.DELETED, commonEntityService.GetListType());
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.DELETED, commonEntityService.GetListType()); // cteate log record
                logService.OutputLog(log);// output result to log
            }
            else
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
        }

        public int GetProductsAmount()
        {
            return commonEntityService.ListAmount(products);
        }

        public void OutputProducts()
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(products), commonEntityService.GetListType());
            ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // cteate log record
            logService.OutputLog(log);// output result to log
        }
    }
}
