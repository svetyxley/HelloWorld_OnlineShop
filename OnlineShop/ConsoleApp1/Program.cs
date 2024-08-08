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
            SuppliersService suppliersService = new();
            InputManager inputManager = new();
            InputValidator inputValidator = new();
            CommonEntityService<Supplier> commonEntityServiceS = new();
            CommonEntityService<Manufacturer> commonEntityServiceM = new();
            Supplier supplier = new();
            Product product = new();
            Manufacturer manufacturer = new();


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


            ////Cteate new Supplier
            suppliersService.CreateSupplier(inputManager.InputName(inputValidator, commonEntityServiceS.GetListType()), inputManager.InputEDRPU(inputValidator, commonEntityServiceS.GetListType()), connectionString);

            ////Output all sippliers list
            //suppliersService.OutputSuppliers(suppliersService.GetAllSupliers(connectionString));

            ////Output Supplier by ID
            //supplier = suppliersService.GetSupplierByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString);
            //if (supplier != null)
            //{
            //    Console.WriteLine(supplier.ToString());
            //}
            //else
            //{
            //    Console.WriteLine("Supplier not found.");
            //}


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
}

