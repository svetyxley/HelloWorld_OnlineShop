
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;

namespace ConsoleApp1
{
    internal class ProductConsoleFlow
    {
        ProductsService productsService = new();
        InputManager inputManager = new();
        InputValidator inputValidator = new();
        CommonEntityService<Product> commonEntityServiceS = new();
        Product Product = new();

        //Menu 1
        public void CreateNewProduct(string connectionString)
        {
            productsService.CreateProduct(
                inputManager.InputName(inputValidator, commonEntityServiceS.GetListType()), 
                inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()),
                inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()),
                inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()),
                inputManager.InputPrice(inputValidator, commonEntityServiceS.GetListType()), connectionString);
        }

        //Menu 2
        public void OutputAllProducts(string connectionString)
        {
            productsService.OutputProducts(productsService.GetAllProducts(connectionString));
        }

        //Menu 3
        public void GetProductByID(string connectionString)
        {
            var product = productsService.GetProductByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString);
            if (product != null)
            {
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

        }

        //Menu 4
        public void GetProductByName(string connectionString)
        {
            Console.Write($"Enter Product Name for search: ");
            var name = Console.ReadLine();
            var product = productsService.GetProductByName(name, connectionString);
            if (product != null)
            {
                Console.Write("Product: ");
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        //Menu 5
        public void UpdateProductNameByID(string connectionString)
        {
            Console.Write($"Enter Product ID to update Name: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product Name to update: ");
            var name = Console.ReadLine();
            var product = productsService.UpdateProductName(id, name, connectionString);
            if (product != null)
            {
                Console.Write("updated Product: ");
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        //Menu 6
        public void UpdateProductCategoryByID(string connectionString)
        {
            Console.Write($"Enter Product ID for update Category: ");
            var productID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product Category to update: ");
            var categoryID = int.Parse(Console.ReadLine());
            var product = productsService.UpdateProductCategory(productID, categoryID, connectionString);
            if (product != null)
            {
                Console.Write("updated Product: ");
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        //Menu 7
        public void UpdateProductManufacturerByID(string connectionString)
        {
            Console.Write($"Enter Product ID for update Manufacturer: ");
            var productID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product Manufacturer to update: ");
            var manufacturerID = int.Parse(Console.ReadLine());
            var product = productsService.UpdateProductManufacturer(productID, manufacturerID, connectionString);
            if (product != null)
            {
                Console.Write("updated Product: ");
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        //Menu 8
        public void UpdateProductSupplierByID(string connectionString)
        {
            Console.Write($"Enter Product ID for update Supplier: ");
            var productID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product SupplierID to update: ");
            var supplierID = int.Parse(Console.ReadLine());
            var product = productsService.UpdateProductSupplier(productID, supplierID, connectionString);
            if (product != null)
            {
                Console.Write("updated Product: ");
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        //Menu 9
        public void UpdateProductPrice(string connectionString)
        {
            Console.Write($"Enter Product ID for update price:");
            var productID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product price to update: ");
            var price = Double.Parse(Console.ReadLine());
            var product = productsService.UpdateProductPrice(productID, price, connectionString);
            if (product != null)
            {
                Console.Write("updated Product: ");
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        //Menu 10
        public void DeleteProductByID(string connectionString)
        {
            Console.WriteLine(productsService.DeleteProductByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString));
        }
    }
}
