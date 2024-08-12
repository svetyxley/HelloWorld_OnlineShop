
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;

namespace ConsoleApp1
{
    internal class SupplierConsoleFlow
    {
        SuppliersService suppliersService = new();
        InputManager inputManager = new();
        InputValidator inputValidator = new();
        CommonEntityService<Supplier> commonEntityServiceS = new();
        Supplier supplier = new();

        //Menu 1
        public void CreateNewSupplier(string connectionString)
        {
            suppliersService.CreateSupplier(inputManager.InputName(inputValidator, commonEntityServiceS.GetListType()), inputManager.InputEDRPU(inputValidator, commonEntityServiceS.GetListType()), connectionString);
        }

        //Menu 2
        public void OutputAllSuppliers(string connectionString)
        {
            suppliersService.OutputSuppliers(suppliersService.GetAllSuppliers(connectionString));
        }

        //Menu 3
        public void GetSupplierByID(string connectionString)
        {
            supplier = suppliersService.GetSupplierByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString);
            if (supplier != null)
            {
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }

        }

        //Menu 4
        public void GetSupplierByName(string connectionString)
        {
            Console.Write($"Enter Supplier Name for search: ");
            var supplierName = Console.ReadLine();
            supplier = suppliersService.GetSupplierByName(supplierName, connectionString);
            if (supplier != null)
            {
                Console.Write("Supplier: ");
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        //Menu 5
        public void GetSupplierByCode(string connectionString) 
        {
            Console.Write($"Enter Supplier code EDRPOU for search: ");
            var codeEDRPOU = Console.ReadLine();
            supplier = suppliersService.GetSupplierByCode(codeEDRPOU, connectionString);
            if (supplier != null)
            {
                Console.WriteLine("EDRPOU: ");
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        //Menu 6
        public void UpdateSupplierNameByID(string connectionString)
        {
            Console.Write($"Enter Supplier ID to update Name: ");
            var supplierID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Supplier Name to update: ");
            var supplierName = Console.ReadLine();
            supplier = suppliersService.UpdateSupplierNameByID(supplierID, supplierName, connectionString);
            if (supplier != null)
            {
                Console.Write("updated Supplier: ");
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        //Menu 7
        public void UpdateSupplierCodeByID(string connectionString) 
        {
            Console.Write($"Enter Supplier ID for update EDRPOU: ");
            var supplierID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Supplier EDRPOU to update: ");
            var supplierEDRPOU = Console.ReadLine();
            supplier = suppliersService.UpdateSupplierCodeByID(supplierID, supplierEDRPOU, connectionString);
            if (supplier != null)
            {
                Console.Write("updated Supplier: ");
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        //Menu 8
        public void DeleteSupplierByID(string connectionString)
        {
            Console.WriteLine(suppliersService.DeleteSupplierByID(inputManager.InputID(inputValidator, commonEntityServiceS.GetListType()), connectionString));
        }
    }
}
