using OnlineShop.BusinessLayer.Managers;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {

            ProductsCatalogFlow mainFlow = new ProductsCatalogFlow();
            mainFlow.CatalogProcesses();
        }
    }
}

