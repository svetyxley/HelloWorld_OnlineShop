namespace OnlineShop.Items
{
    internal class Supplier(int manufacturerID, string manufacturerName, string manufacturerEDRPOU)
    {
        public int SupplierID { get; init; } = manufacturerID;
        public string SupplierName { get; set; } = manufacturerName;
        public string SupplierEDRPOU { get; set; } = manufacturerEDRPOU;

        // Override the ToString method
        public override string ToString()
        {
            return $"SupplierID: {SupplierID}, SupplierName: {SupplierName}, SupplierEDRPOU: {SupplierEDRPOU}";
        }
    }
}
