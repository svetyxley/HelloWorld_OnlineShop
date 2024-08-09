using OnlineShop.Entities;

public static class ProductStocksExtensions
{
    public static bool IsInStock(this ProductStocks productStock)
    {
        return productStock.ProductAmount > 0;
    }

    public static string GetStockSummary(this ProductStocks productStock)
    {
        return $"{productStock.product?.ProductName ?? "Unknown Product"} has {productStock.ProductAmount} units in stock.";
    }
}