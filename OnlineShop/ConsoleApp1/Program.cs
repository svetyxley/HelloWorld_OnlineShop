using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnlineShop;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.BusinessLayer.Managers;


namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ManufacturesService manufacturesService =  new ManufacturesService();
            SuppliersService suppliersService = new SuppliersService();
            InputManager inputManager = new();
            InputValidator inputValidator = new();
            CommonEntityService<Supplier> commonEntityService = new(); 

        var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.SvitlanaL.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SvitlanaL");

            var manufacturer = manufacturesService.GetManufacturerByID(12, connectionString);

            var supplier = suppliersService.GetSupplierByID(2, connectionString);
            suppliersService.CreateSupplier(inputManager.InputName(inputValidator,commonEntityService.GetListType()), inputManager.InputEDRPU(inputValidator, commonEntityService.GetListType()), connectionString);

            //       ProductsCatalogFlow mainFlow = new ProductsCatalogFlow();
            //           mainFlow.CatalogProcesses();
        }
    }
}

