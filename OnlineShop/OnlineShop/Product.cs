using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class Product
    {
        public int ProductId { get; init; }
        public string ProductName { get; set; }
        public ProductCategory Category { get; set; }
        public Manufacturer ProductManufacturer { get; set; }
        public Supplier ProductSupplier { get; set; }

        public double ProductPrice { get; set; }

        public Product(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
        public override string ToString()
        {
            return $"ProductId: {ProductId}, ProductName: {ProductName}, Category: {Category}, ProductManufacturer: {ProductManufacturer}, ProductSupplier: {ProductSupplier}, ProductPrice: {ProductPrice}";
        }
    }
}
