using Microsoft.Extensions.Configuration;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.SvitlanaL.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SvitlanaL");

            var manager = new ManufacturesService();
            var manufacturer = manager.GetManufacturerByID(1, connectionString);

            ProductsCatalogFlow mainFlow = new ProductsCatalogFlow();
            mainFlow.CatalogProcesses();
        }
    }
}

