using OnlineShop.Constants;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class ProductsService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator idGenerator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Product> commonEntityService = new();
        private ManufacturesService manufacturesService = new();
        private SuppliersService suppliersService = new();


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
            return new Product(productId, productName, manufacturesService.GetManufacturerByID(), suppliersService.GetSupplierByID(), productPrice);
        }
        public void AddToProducts()
        {
            products.Add(CreateProduct());
            outputManager.Write(NotificationConstants.ADDED, commonEntityService.GetListType());
        }

        public Product GetProductByID()
        {
            var productID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var product = products.FirstOrDefault(products => products.ProductID == productID);
            if (product == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            else
            {
                outputManager.Write(product.ToString(), commonEntityService.GetListType());
            }
            return product;
        }
        public Product UpdateProduct()
        {
            var productID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var product = products.FirstOrDefault(products => products.ProductID == productID);
            if (product == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return product;
        }

        public void DeleteProductByID()
        {
            var productID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var product = products.FirstOrDefault(product => product.ProductID == productID);
            if (product != null)
            {
                products.Remove(product);
                outputManager.Write(NotificationConstants.DELETED, commonEntityService.GetListType());
            }
            else
            { 
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType()); 
            }
        }

        public int GetProductsAmount() 
        {
            return commonEntityService.ListAmount(products);
        }

        public void OutputProducts()
        {
            outputManager.Write(commonEntityService.OutputList(products), commonEntityService.GetListType());
        }
    }
}
