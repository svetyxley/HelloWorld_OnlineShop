using OnlineShop.Entities;

namespace OnlineShop.Services
{
    internal class ProductsService
    {
        private List<Product> products = new();
        private InputConsoleManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator IDGenerator = new();

        public Product CreateProduct()
        {
            int productId = IDGenerator.InputID(products);
            string productName = inputManager.InputName(inputValidator);
            return new Product(productId, productName);
        }
        public bool AddNewProduct()
        {
            products.Add(CreateProduct());
            return true;
        }

        public bool Add(Product product)
        {
            products.Add(product);
            return true;
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
