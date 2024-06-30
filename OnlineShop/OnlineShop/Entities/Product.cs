using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace OnlineShop.Data.Entities
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int ProductCategoryID { get; set; }

        public int ManufacturerId { get; set; }

        public int SupplierID { get; set; }

        public uint? ProductPrice { get; set; }



        public Manufacturer? ProductManufacturer { get; set; }
        public Supplier? ProductSupplier { get; set; }


        public Product()
        {

        }

        public Product(int id, string name)
        {
            ProductID = id;
            ProductName = name;
        }

        public Product(int id,string name, uint price)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
        }



        public Product(int productID, string productName, int productCategoryId, int productManufacturerId, int productSupplierId, uint productPrice)
        {
            ProductID = productID;
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

