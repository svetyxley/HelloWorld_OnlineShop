namespace OnlineShop.Entities
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Manufacturer ProductManufacturer { get; set; }
        public Supplier ProductSupplier { get; set; }
        public double ProductPrice { get; set; }

        public Product(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }

        public Product()
        {
        }
        public override string ToString()
        {
            return $"ProductId: {ProductId}, ProductName: {ProductName}, ProductManufacturer: {ProductManufacturer}, ProductSupplier: {ProductSupplier}, ProductPrice: {ProductPrice}";
        }
    }
}

