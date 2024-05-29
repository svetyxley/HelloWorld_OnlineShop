using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class Supplier
    {
        public int SupplierID { get; init; }
        public string SupplierName { get; set; }
        public string SupplierEDRPOU { get; set; }

        public Supplier(int manufacturerID, string manufacturerName, string manufacturerEDRPOU)
        {
            SupplierID = manufacturerID;
            SupplierName = manufacturerName;
            SupplierEDRPOU = manufacturerEDRPOU;
        }

        // Override the ToString method
        public override string ToString()
        {
            return $"SupplierID: {SupplierID}, SupplierName: {SupplierName}, SupplierEDRPOU: {SupplierEDRPOU}";
        }
    }
}
