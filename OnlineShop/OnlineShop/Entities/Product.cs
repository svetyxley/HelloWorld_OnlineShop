using OnlineShop.BusinessLayer.Services;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace OnlineShop.Data.Entities
{
    public class Product
    {
        public required int ProductID { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int ProductCategoryID { get; set; }

        public int ManufacturerId { get; set; }

        public int SupplierID { get; set; }

        public uint? ProductPrice { get; set; }



        public Manufacturer? ProductManufacturer { get; set; }
        public Supplier? ProductSupplier { get; set; }


        public Product()
        {
            ProductID = JsonController<Product>.LoadIndexer();
        }



        public Product( string productName, int productCategoryId, int productManufacturerId, int productSupplierId, uint productPrice)
        {
            ProductID = JsonController<Product>.LoadIndexer();
            ProductName = productName;
            ProductCategoryID = productCategoryId;
            ManufacturerId = productManufacturerId;
            SupplierID = productSupplierId;
            ProductPrice = productPrice;    
        }

        public override string ToString()
        {
            return $"ProductID: {ProductID}, ProductName: {ProductName}, ProductManufacturer: {ManufacturerId}, ProductSupplier: {SupplierID}, ProductPrice: {ProductPrice}";
        }
    }
}

