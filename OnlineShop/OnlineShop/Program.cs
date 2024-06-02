// See https://aka.ms/new-console-template for more information
using OnlineShop.EntityServices;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductsService productsService = new ProductsService();
        ManufacturesService manufactureService = new ManufacturesService();
        SuppliersService suppliersService = new SuppliersService();

        productsService.AddToProducts();
        Console.WriteLine(productsService.ToString());

        manufactureService.AddToManufacturers();
        Console.WriteLine(manufactureService.ToString());

        suppliersService.AddToSuppliers();
        Console.WriteLine(suppliersService.ToString());

        suppliersService.DeleteSupplierByID(1);

        Console.WriteLine(suppliersService.ToString());
    }
}