﻿
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
        public async Task CreateNewProduct(string connectionString)
        {
            productsService.CreateProduct(
                inputManager.InputName(inputValidator, commonEntityServiceS.GetListType()), 
                inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()),
                inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()),
                inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()),
                inputManager.InputPrice(inputValidator, commonEntityServiceS.GetListType()), connectionString);
        }

        //Menu 2
        public async Task OutputAllProducts(string connectionString)
        {
            await productsService.OutputProducts(await productsService.GetAllProducts(connectionString));
        }

        //Menu 3
        public async Task GetProductByID(string connectionString)
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
        public async Task GetProductByName(string connectionString)
        {
            Console.Write($"Enter Product Name for search: ");
            var name = Console.ReadLine();
            var product = await productsService.GetProductByName(name, connectionString);
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
        public async Task UpdateProductNameByID(string connectionString)
        {
            Console.Write($"Enter Product ID to update Name: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product Name to update: ");
            var name = Console.ReadLine();
            var product = await productsService.UpdateProductName(id, name, connectionString);
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
        public async Task UpdateProductCategoryByID(string connectionString)
        {
            Console.Write($"Enter Product ID for update Category: ");
            var productID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product Category to update: ");
            var categoryID = int.Parse(Console.ReadLine());
            var product = await productsService.UpdateProductCategory(productID, categoryID, connectionString);
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
        public async Task UpdateProductManufacturerByID(string connectionString)
        {
            Console.Write($"Enter Product ID for update Manufacturer: ");
            var productID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product Manufacturer to update: ");
            var manufacturerID = int.Parse(Console.ReadLine());
            var product = await productsService.UpdateProductManufacturer(productID, manufacturerID, connectionString);
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
        public async Task UpdateProductSupplierByID(string connectionString)
        {
            Console.Write($"Enter Product ID for update Supplier: ");
            var productID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product SupplierID to update: ");
            var supplierID = int.Parse(Console.ReadLine());
            var product = await productsService.UpdateProductSupplier(productID, supplierID, connectionString);
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
        public async Task UpdateProductPrice(string connectionString)
        {
            Console.Write($"Enter Product ID for update price:");
            var productID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Product price to update: ");
            var price = Double.Parse(Console.ReadLine());
            var product = await productsService.UpdateProductPrice(productID, price, connectionString);
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
        public async Task DeleteProductByID(string connectionString)
        {
            Console.WriteLine(await productsService.DeleteProductByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString));
        }
    }
}
