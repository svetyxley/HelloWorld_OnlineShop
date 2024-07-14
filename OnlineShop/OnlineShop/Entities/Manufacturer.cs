using OnlineShop.BusinessLayer.Services;

namespace OnlineShop.Data.Entities
{
    public class Manufacturer
    {
        public required int ManufacturerID { get; set; }
        public string? ManufacturerName { get; set; } = "";
        public string? ManufacturerEDRPOU { get; set; } = "";

        public Manufacturer(int manufacturerID, string manufacturerName, string manufacturerEDRPOU)

        {
            ManufacturerID = JsonController<Manufacturer>.LoadIndexer();
            ManufacturerName = manufacturerName;
            ManufacturerEDRPOU = manufacturerEDRPOU;
        }

        // Конструктор за замовчуванням
        public Manufacturer()
        {
            ManufacturerID = JsonController<Manufacturer>.LoadIndexer();
        }

        // Override the ToString method
        public override string ToString()
        {
            return $"ManufacturerID: {ManufacturerID}, ManufacturerName: {ManufacturerName}, ManufacturerEDRPOU: {ManufacturerEDRPOU}";
        }
    }
}