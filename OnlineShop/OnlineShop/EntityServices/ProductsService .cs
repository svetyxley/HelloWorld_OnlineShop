using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
     public class ProductsService
    {
        private InputConsoleManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator IDGenerator = new();

        private List<Product> products = new List<Product>()
        {         
            new Product(1, "Product1"),
            new Product(2, "Product2"),
            new Product(3, "Product3")
        };


        public Product CreateProduct()
        {
            int productId = IDGenerator.InputID(products);
            string productName = inputManager.InputName(inputValidator, GetListType());
            return new Product(productId, productName);
        }
        public bool AddToProducts()
        {
            products.Add(CreateProduct());
            return true;
        }

        public Product GetProduct(int productID)
        {
            var product = products.FirstOrDefault(products => products.ProductID == productID);
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {productID} not found.");
            }
            return product;
        }
        public Product UpdateProduct(int productID)
        {
            var product = products.FirstOrDefault(products => products.ProductID == productID);
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {productID} not found.");
            }
            return product;
        }

        public bool DeleteProductbyID(int productID)
        {
            var product = products.FirstOrDefault(product => product.ProductID == productID);
            if (product != null)
            {
                return products.Remove(product);
            }
            return false;
        }

        public string GetListType()
        {
            return products.AsQueryable().ElementType.Name;
        }

        // Override the ToString method
        public override string ToString()
        {
            if (products.Count == 0)
                return "No products in the list.";

            string result = "Products:\n";
            foreach (var product in products)
            {
                result += product.ToString() + "\n";
            }
            return result;
        }

    }
}
