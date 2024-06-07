using OnlineShop.EntityServices;

namespace OnlineShop
{
    public class ProductsCatalogFlow
    {
        public void CatalogProcesses()
        {
            ProductsService productsService = new ProductsService();
            ManufacturesService manufactureService = new ManufacturesService();
            SuppliersService suppliersService = new SuppliersService();

            //Додавання нового виробника та вивід повного списка виробників
            manufactureService.AddToManufacturers();
            manufactureService.OutputManufacturers();

            //Додавання нового виробника та вивід повного списка постачальників
            suppliersService.AddToSuppliers();
            suppliersService.OutputSuppliers();

            //Додавання нового продукту та вивід повного списка продуктів

            productsService.AddToProducts();
            productsService.OutputProducts();

            //Робота зі списком продуктів
           productsService.DeleteProductByID(); //видалення продукту за неіснуючім ID
           productsService.GetProductByID();   //Отримання продукту за неіснуючім IDID
        }
    }
}
