using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ManufacturersService ManufacturersService = new();
            InputManager inputManager = new();
            InputValidator inputValidator = new();
            CommonEntityService<Supplier> commonEntityServiceS = new();
            CommonEntityService<Manufacturer> commonEntityServiceM = new();
            SupplierConsoleFlow supplierFlow = new SupplierConsoleFlow();
            ManufacturerConsoleFlow manufacturerFlow = new ManufacturerConsoleFlow();
            ProductConsoleFlow productFlow = new ProductConsoleFlow();

            // Configurations
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.SvitlanaL.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Master");

            var datAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(x => x.GetName().Name == "OnlineShop.Data");

            // Migrations
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddLogging(c => c.AddFluentMigratorConsole())
                    .AddFluentMigratorCore()
                    .ConfigureRunner(rb => rb.AddSqlServer2012()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(datAssembly).For.Migrations());
                })
                .Build();

            host.MigrateDatabase();

            // Menu
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("What do you want to work with? Please, make your choice: ");
                Console.WriteLine("Main Menu:");
                Console.WriteLine("S: Supplier");
                Console.WriteLine("M: Manufacturer");
                Console.WriteLine("P: Product");

                string mainChoice = Console.ReadLine();
                switch (mainChoice)
                {
                    case "S":
                        {
                            Console.WriteLine("Supplier Menu:");
                            Console.WriteLine("1. Add new Supplier");
                            Console.WriteLine("2. Get all suppliers list");
                            Console.WriteLine("3. Search Supplier by ID");
                            Console.WriteLine("4. Search Supplier by Name");
                            Console.WriteLine("5. Search Supplier by EDRPOU");
                            Console.WriteLine("6. Update Supplier name");
                            Console.WriteLine("7. Update Supplier EDRPOU");
                            Console.WriteLine("8. Delete Supplier");
                            Console.WriteLine("9. Exit");
                            Console.Write("Please, make your choice: ");

                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    supplierFlow.CreateNewSupplier(connectionString);
                                    break;
                                case "2":
                                    supplierFlow.OutputAllSuppliers(connectionString);
                                    break;
                                case "3":
                                    supplierFlow.GetSupplierByID(connectionString);
                                    break;
                                case "4":
                                    supplierFlow.GetSupplierByName(connectionString);
                                    break;
                                case "5":
                                    supplierFlow.GetSupplierByCode(connectionString);
                                    break;
                                case "6":
                                    supplierFlow.UpdateSupplierNameByID(connectionString);
                                    break;
                                case "7":
                                    supplierFlow.UpdateSupplierCodeByID(connectionString);
                                    break;
                                case "8":
                                    supplierFlow.DeleteSupplierByID(connectionString);
                                    break;
                                case "9":
                                    exit = true;
                                    Console.WriteLine("Exit...");
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice. Try again.");
                                    break;
                            }
                            Console.WriteLine();
                            break;
                        }

                    case "M":
                        {
                            Console.WriteLine("Manufacturer Menu:");
                            Console.WriteLine("1. Add new Manufacturer");
                            Console.WriteLine("2. Get all manufacturers list");
                            Console.WriteLine("3. Search Manufacturer by ID");
                            Console.WriteLine("4. Search Manufacturer by Name");
                            Console.WriteLine("5. Search Manufacturer by EDRPOU");
                            Console.WriteLine("6. Update Manufacturer name");
                            Console.WriteLine("7. Update Manufacturer EDRPOU");
                            Console.WriteLine("8. Delete Manufacturer");
                            Console.WriteLine("9. Exit");
                            Console.Write("Make your choice: ");

                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    manufacturerFlow.CreateNewManufacturer(connectionString);
                                    break;
                                case "2":
                                    manufacturerFlow.OutputAllManufacturers(connectionString);
                                    break;
                                case "3":
                                    manufacturerFlow.GetManufacturerByID(connectionString);
                                    break;
                                case "4":
                                    manufacturerFlow.GetManufacturerByName(connectionString);
                                    break;
                                case "5":
                                    manufacturerFlow.GetManufacturerByCode(connectionString);
                                    break;
                                case "6":
                                    manufacturerFlow.UpdateManufacturerNameByID(connectionString);
                                    break;
                                case "7":
                                    manufacturerFlow.UpdateManufacturerCodeByID(connectionString);
                                    break;
                                case "8":
                                    manufacturerFlow.DeleteManufacturerByID(connectionString);
                                    break;
                                case "9":
                                    exit = true;
                                    Console.WriteLine("Exit...");
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice. Try again.");
                                    break;
                            }
                            Console.WriteLine();
                            break;
                        }

                    case "P":
                        {
                            Console.WriteLine("Product Menu:");
                            Console.WriteLine("1. Add new Product");
                            Console.WriteLine("2. Get all products list");
                            Console.WriteLine("3. Search Product by ID");
                            Console.WriteLine("4. Search Product by Name");
                            Console.WriteLine("5. Update Product name");
                            Console.WriteLine("6. Update Product Category");
                            Console.WriteLine("7. Update Product Manufacturer");
                            Console.WriteLine("8. Update Product Supplier");
                            Console.WriteLine("9. Update Product Price");
                            Console.WriteLine("10. Delete Product");
                            Console.WriteLine("11. Exit");
                            Console.Write("Make your choice: ");

                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    productFlow.CreateNewProduct(connectionString);
                                    break;
                                case "2":
                                    productFlow.OutputAllProducts(connectionString);
                                    break;
                                case "3":
                                    productFlow.GetProductByID(connectionString);
                                    break;
                                case "4":
                                    productFlow.GetProductByName(connectionString);
                                    break;
                                case "5":
                                    productFlow.UpdateProductNameByID(connectionString);
                                    break;
                                case "6":
                                    productFlow.UpdateProductCategoryByID(connectionString);
                                    break;
                                case "7":
                                    productFlow.UpdateProductManufacturerByID(connectionString);
                                    break;
                                case "8":
                                    productFlow.UpdateProductSupplierByID(connectionString);
                                    break;
                                case "9":
                                    productFlow.UpdateProductPrice(connectionString);
                                    break;
                                case "10":
                                    productFlow.DeleteProductByID(connectionString);
                                    break;
                                case "11":
                                    exit = true;
                                    Console.WriteLine("Exit...");
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice. Try again.");
                                    break;
                            }
                            Console.WriteLine();
                            break;
                        }
                }
            }
        }
    }
}
