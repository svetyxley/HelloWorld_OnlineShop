namespace OnlineShop.Items
{
    internal class Product(int productId, string productName)
    {
        public int ProductId { get; set; } = productId;
        public string ProductName { get; set; } = productName;
        public Manufacturer ProductManufacturer { get; set; }
        public Supplier ProductSupplier { get; set; }

        public double ProductPrice { get; set; }
        public override string ToString()
        {
            return $"ProductId: {ProductId}, ProductName: {ProductName}, ProductManufacturer: {ProductManufacturer}, ProductSupplier: {ProductSupplier}, ProductPrice: {ProductPrice}";
        }
    }
}
