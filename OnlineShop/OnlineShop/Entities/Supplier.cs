using OnlineShop.BusinessLayer.Services;

namespace OnlineShop.Data.Entities
{
    public class Supplier
    {
        public required int SupplierID { get; init; }
        public string? SupplierName { get; set; } = string.Empty;
        public string? SupplierEDRPOU { get; set; } = string.Empty;

        public Supplier(int supplierID, string supplierName, string supplierEDRPOU)
        {
            SupplierID = JsonController<Supplier>.LoadIndexer();
            SupplierName = supplierName;
            SupplierEDRPOU = supplierEDRPOU;
        }

        public Supplier()
        {
            SupplierID = JsonController<Supplier>.LoadIndexer();
        }

        // Override the ToString method
        public override string ToString()
        {
            return $"SupplierID: {SupplierID}, SupplierName: {SupplierName}, SupplierEDRPOU: {SupplierEDRPOU}";
        }
    }
}
