using OnlineShop;
using OnlineShop.Records;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductsCatalogFlow mainFlow = new ProductsCatalogFlow();
        mainFlow.CatalogProcesses();
    }
}