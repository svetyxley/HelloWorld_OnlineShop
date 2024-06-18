namespace OnlineShop.Data.Entities
{
    public class ProductStocks
    {
        public Product? product { get; set; }
        public int ProductAmount { get; set; }
        public ProductStocks()
        {

        }
        public ProductStocks(int productAmount)
        {
            ProductAmount = productAmount;
        }
        public ProductStocks(Product _product, int productAmount)
        {
            product = _product;
            ProductAmount = productAmount;
        }
        public override string ToString()
        {
            return $"Product: {product}, Product Amount: {ProductAmount}";
        }
    }
}