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
            ManufacturesService manufacturesService = new();
            InputManager inputManager = new();
            InputValidator inputValidator = new();
            CommonEntityService<Supplier> commonEntityServiceS = new();
            CommonEntityService<Manufacturer> commonEntityServiceM = new();
            SupplierFlow supplierFlow = new SupplierFlow();


            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.SvitlanaL.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SvitlanaL");

            var datAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(x => x.GetName().Name == "OnlineShop.Data");

            //Migrations
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


            //Menu
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add new Supplier");
                Console.WriteLine("2. Get all suppliers list");
                Console.WriteLine("3. Search Supplier by ID");
                Console.WriteLine("4. Search Supplier by Name");
                Console.WriteLine("5. Search Supplier by EDRPOU");
                Console.WriteLine("6. Update Supplier name");
                Console.WriteLine("7. Update Supplier EDRPOU");
                Console.WriteLine("8. Delete Supplier");
                Console.WriteLine("9. Exit");
                Console.Write("Make your choice: ");

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
            }
        }

        //Output Manufacturer by ID


        //           manufacturer = manufacturesService.GetAllManufacturersWithProductsById(1, connectionString);
        //            manufacturer = manufacturesService.GetManufacturerByID(inputManager.InputID(inputValidator, commonEntityServiceM.GetListType()), connectionString);
        //if (manufacturer != null)
        //{
        //    Console.WriteLine(manufacturer.ToString());
        //}
        //else
        //{
        //    Console.WriteLine("Manufacturer not found.");
        //}


        /*            //Output Supplier by ID
                    suppliersService.DeleteSupplierByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString);
                    if (supplier != null)
                    {
                        Console.WriteLine(supplier.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Supplier not found.");
                    }

                    //       ProductsCatalogFlow mainFlow = new ProductsCatalogFlow();
                    //           mainFlow.CatalogProcesses();*/
    }
    }

