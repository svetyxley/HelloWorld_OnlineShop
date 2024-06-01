using OnlineShop.Entities;

namespace OnlineShop.Services
{
    public class SuppliersService
    {
        private List<Supplier> suppliers = new();
        private InputConsoleManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator IDGenerator = new();

        public Supplier CreateSupplier()
        {
            int supplierID = IDGenerator.InputID(suppliers);
            string supplierName = inputManager.InputName(inputValidator);
            string supplierEDRPOU = inputManager.InputName(inputValidator);
            return new Supplier(supplierID, supplierName, supplierEDRPOU);
        }

        public bool AddNewSupplier()
        {
            suppliers.Add(CreateSupplier());
            return true;
        }

        public bool Add(Supplier supplier)
        {
            suppliers.Add(supplier);
            return true;
        }
    }
}
