using System.Configuration;
using System.Reflection;
using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data;
using OnlineShop.Entities;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Dev.json")
                .AddJsonFile("appsettings.Qa.json")
                .Build();

            var maxUsers = configuration["EdPlatformMaxUsers"];
            var connectionString = configuration.GetConnectionString("Master");

            var name = configuration["Name"];
            var timeout = configuration["Timeout"];


            var manager = new ManufacturesService();
            var manufacturer = manager.GetManufacturerByID(1, connectionString);






            ProductsCatalogFlow mainFlow = new ProductsCatalogFlow();
            mainFlow.CatalogProcesses();
        }
    }



    /*
     var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Dev.json")
                .AddJsonFile("appsettings.Release.json")
                .AddJsonFile("appsettings.QA.json")
                .Build();


            var a = configuration["Name"];
            var connectionStr = configuration.GetConnectionString("Master");

            using (var connection = new SqlConnection(connectionStr))
            {

                connection.Open();

    var res = connection.Execute("UpdateМanufacturer", new { @ID = 1, @Name = "Norven1" });

;               var str = "'Norven'; drop table aaa;";
                var sql = $"select* FROM Manufacturer where [ManufacturerName] like {str}";

                var result = connection
                    .Query<Manufacturer>(sql);

                connection.Close();
            }
      

    var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddLogging(c => c.AddFluentMigratorConsole())
                        .AddFluentMigratorCore()
                        .ConfigureRunner(c => c.AddSqlServer2012()
                            .WithGlobalConnectionString(configuration.GetConnectionString("SqlConnection"))
                            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
                })
                //.UseSerilog()
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                migrationService.ListMigrations();
                migrationService.MigrateUp();
            }
     */
}

