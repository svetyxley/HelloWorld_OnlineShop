﻿namespace OnlineShop.Data.Entities
{
    public class Supplier
    {
        public int SupplierID { get; init; }
        public string? SupplierName { get; set; } = string.Empty;
        public string? SupplierEDRPOU { get; set; } = string.Empty;

        public Supplier(int supplierID, string supplierName, string supplierEDRPOU)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
            SupplierEDRPOU = supplierEDRPOU;
        }

        public Supplier()
        {
        }

        // Override the ToString method
        public override string ToString()
        {
            return $"SupplierID: {SupplierID}, SupplierName: {SupplierName}, SupplierEDRPOU: {SupplierEDRPOU}";
        }
    }
}
