using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class ManufacturesService
    {
        private InputConsoleManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator IDGenerator = new();

        private List<Manufacturer> manufacturers = new List<Manufacturer>() 
        {
           new(1, "Manufacturer1", "ManufacturerEDRPOU1"),
           new(2, "Manufacturer2", "ManufacturerEDRPOU2"),
           new(3, "Manufacturer3", "ManufacturerEDRPOU3")
        };
        public Manufacturer CreateManufacturer()
        {
            int manufacturerID = IDGenerator.InputID(manufacturers);
            string manufacturerName = inputManager.InputName(inputValidator, GetListType());
            string manufacturerEDRPOU = inputManager.InputEDRPU(inputValidator, GetListType());
            return new Manufacturer(manufacturerID, manufacturerName, manufacturerEDRPOU);
        }

        public bool AddToManufacturers()
        {
            manufacturers.Add(CreateManufacturer());
            return true;
        }
        public Manufacturer GetManufacturer(int manufacturerID)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturers => manufacturers.ManufacturerID == manufacturerID);
            if (manufacturer == null)
            {
                throw new InvalidOperationException($"Manufacturer with ID {manufacturerID} not found.");
            }
            return manufacturer;
        }

        public Manufacturer UpdateManufacturer(int manufacturerID)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturer => manufacturer.ManufacturerID == manufacturerID);
            if (manufacturer == null)
            {
                throw new InvalidOperationException($"Manufacturer with ID {manufacturerID} not found.");
            }
            return manufacturer;
        }

        public bool DeleteManufacturerByID(int manufacturerID)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturer => manufacturer.ManufacturerID == manufacturerID);
            if (manufacturer != null)
            {
                return manufacturers.Remove(manufacturer);
            }
            return false;
        }

        public string GetListType()
        {
            return manufacturers.AsQueryable().ElementType.Name;
        }

        // Override the ToString method
        public override string ToString()
        {
            if (manufacturers.Count == 0)
                return $"No manufacturers in the list.";

            string result = "Manufacturers:\n";
            foreach (var manufacturer in manufacturers)
            {
                result += manufacturer.ToString() + "\n";
            }
            return result;
        }
    }
}
