using OnlineShop.Entities;

namespace OnlineShop.Services
{
    internal class ManufacturesService
    {
        private List<Manufacturer> manufacturers = new();
        private InputConsoleManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator IDGenerator = new();

        public Manufacturer CreateSupplier()
        {
            int manufacturerID = IDGenerator.InputID(manufacturers);
            string manufacturerName = inputManager.InputName(inputValidator);
            string manufacturerEDRPOU = inputManager.InputName(inputValidator);
            return new Manufacturer(manufacturerID, manufacturerName, manufacturerEDRPOU);
        }

        public bool AddNewSupplier()
        {
            manufacturers.Add(CreateSupplier());
            return true;
        }
        public bool Add(Manufacturer manufacturer)
        {
            manufacturers.Add(manufacturer);
            return true;
        }

        // Override the ToString method
        public override string ToString()
        {
            if (manufacturers.Count == 0)
                return "No manufacturers in the list.";

            string result = "Manufacturers:\n";
            foreach (var product in manufacturers)
            {
                result += product.ToString() + "\n";
            }
            return result;
        }
    }
}
