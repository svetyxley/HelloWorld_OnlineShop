namespace OnlineShop.Items
{
    internal class Manufacturer(int manufacturerID, string manufacturerName, string manufacturerEDRPOU)
    {
        public int ManufacturerID { get; init; } = manufacturerID;
        public string ManufacturerName { get; set; } = manufacturerName;
        public string ManufacturerEDRPOU { get; set; } = manufacturerEDRPOU;

        // Override the ToString method
        public override string ToString()
        {
            return $"ManufacturerID: {ManufacturerID}, ManufacturerName: {ManufacturerName}, ManufacturerEDRPOU: {ManufacturerEDRPOU}";
        }
    }
}