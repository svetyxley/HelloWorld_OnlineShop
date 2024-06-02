namespace OnlineShop.Entities
{
    public class Product
    {
        public int ProductID { get; init; }
        public string ProductName { get; set; }
        public Manufacturer? ProductManufacturer { get; set; }
        public Supplier? ProductSupplier { get; set; }
        public double? ProductPrice { get; set; }

        public Product(int productID, string productName)
        {
            ProductID = productID;
            ProductName = productName;
        }

        public Product()
        {
        }
        public override string ToString()
        {
            return $"ProductID: {ProductID}, ProductName: {ProductName}, ProductManufacturer: {ProductManufacturer}, ProductSupplier: {ProductSupplier}, ProductPrice: {ProductPrice}";
        }
    }
}

