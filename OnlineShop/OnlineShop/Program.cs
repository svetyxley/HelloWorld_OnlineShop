// See https://aka.ms/new-console-template for more information
using OnlineShop;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductsCatalogFlow mainFlow = new ProductsCatalogFlow();
        mainFlow.CatalogProcesses();
    }
}