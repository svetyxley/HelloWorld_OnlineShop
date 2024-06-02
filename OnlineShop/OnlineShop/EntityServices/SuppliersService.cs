using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class SuppliersService
    {
        private InputConsoleManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator IDGenerator = new();

        private List<Supplier> suppliers = new List<Supplier>()
        {
        new Supplier(1, "Supplier1", "SupplierEDRPOU1"),
        new Supplier(2, "Supplier2", "SupplierEDRPOU2"),
        new Supplier(3, "Supplier3", "SupplierEDRPOU3")
        };

        public Supplier CreateSupplier()
        {
            int supplierID = IDGenerator.InputID(suppliers);
            string supplierName = inputManager.InputName(inputValidator, GetListType());
            string supplierEDRPOU = inputManager.InputEDRPU(inputValidator, GetListType());
            return new Supplier(supplierID, supplierName, supplierEDRPOU);
        }

        public bool AddToSuppliers()
        {
            suppliers.Add(CreateSupplier());
            return true;
        }

        public Supplier GetSupplier(int supplierID)
        {
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier == null)
            {
                throw new InvalidOperationException($"Supplier with ID {supplierID} not found.");
            }
            return supplier;
        }

        //додати логику апдейту
        public Supplier UpdateSupplier(int supplierID)
        {
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier == null)
            {
                throw new InvalidOperationException($"Supplier with ID {supplierID} not found.");
            }
            return supplier;
        }


        public bool DeleteSupplierByID(int supplierID)
        {
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier != null)
            {
                return suppliers.Remove(supplier);
            }
            return false;
        }

        public string GetListType() {
            return suppliers.AsQueryable().ElementType.Name;
        }
        public override string ToString()
        {
            if (suppliers.Count == 0)
                return "No suppliers in the list.";

            string result = "Suppliers:\n";
            foreach (var supplier in suppliers)
            {
                result += supplier.ToString() + "\n";
            }
            return result;
        }
    }
}