
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;

namespace ConsoleApp1
{
    internal class ManufacturerConsoleFlow
    {
        ManufacturersService manufacturersService = new();
        InputManager inputManager = new();
        InputValidator inputValidator = new();
        CommonEntityService<Manufacturer> commonEntityServiceS = new();
        Manufacturer manufacturer = new();

        //Menu 1
        public void CreateNewManufacturer(string connectionString)
        {
            manufacturersService.CreateManufacturer(inputManager.InputName(inputValidator, commonEntityServiceS.GetListType()), inputManager.InputEDRPU(inputValidator, commonEntityServiceS.GetListType()), connectionString);
        }

        //Menu 2
        public void OutputAllManufacturers(string connectionString)
        {
            manufacturersService.OutputManufacturers(manufacturersService.GetAllManufacturers(connectionString));
        }

        //Menu 3
        public void GetManufacturerByID(string connectionString)
        {
            manufacturer = manufacturersService.GetManufacturerByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString);
            if (manufacturer != null)
            {
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }

        }

        //Menu 4
        public void GetManufacturerByName(string connectionString)
        {
            Console.Write($"Enter Manufacturer Name for search: ");
            var manufacturerName = Console.ReadLine();
            manufacturer = manufacturersService.GetManufacturerByName(manufacturerName, connectionString);
            if (manufacturer != null)
            {
                Console.Write("Manufacturer: ");
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }
        }

        //Menu 5
        public void GetManufacturerByCode(string connectionString)
        {
            Console.Write($"Enter Manufacturer code EDRPOU for search: ");
            var codeEDRPOU = Console.ReadLine();
            manufacturer = manufacturersService.GetManufacturerByCode(codeEDRPOU, connectionString);
            if (manufacturer != null)
            {
                Console.WriteLine("EDRPOU: ");
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }
        }

        //Menu 6
        public void UpdateManufacturerNameByID(string connectionString)
        {
            Console.Write($"Enter Manufacturer ID to update Name: ");
            var manufacturerID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Manufacturer Name to update: ");
            var manufacturerName = Console.ReadLine();
            manufacturer = manufacturersService.UpdateManufacturerNameByID(manufacturerID, manufacturerName, connectionString);
            if (manufacturer != null)
            {
                Console.Write("updated Manufacturer: ");
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }
        }

        //Menu 7
        public void UpdateManufacturerCodeByID(string connectionString)
        {
            Console.Write($"Enter Manufacturer ID for update EDRPOU: ");
            var manufacturerID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Manufacturer EDRPOU to update: ");
            var manufacturerEDRPOU = Console.ReadLine();
            manufacturer = manufacturersService.UpdateManufacturerCodeByID(manufacturerID, manufacturerEDRPOU, connectionString);
            if (manufacturer != null)
            {
                Console.Write("updated Manufacturer: ");
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }
        }

        //Menu 8
        public void DeleteManufacturerByID(string connectionString)
        {
            Console.WriteLine(manufacturersService.DeleteManufacturerByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString));
        }
    }
}
