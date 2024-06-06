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
            PurchaseService purchaseService = new PurchaseService();
            EmployeeService employeeService = new EmployeeService();
            BuyerService buyerService = new BuyerService();
            UserService userService = new UserService();

            //Додавання нового виробника та вивід повного списка виробників
            manufactureService.AddToManufacturers();
            manufactureService.OutputManufacturers();

            //Додавання нового виробника та вивід повного списка постачальників
            suppliersService.AddToSuppliers();
            suppliersService.OutputSuppliers();

            //Додавання нового продукту та вивід повного списка продуктів
            productsService.AddToProducts();
            productsService.OutputProducts();

            //Додавання нового користувача та вивід повного списка користувачів
            userService.AddUser();
            userService.OutputUsers();

            //Додавання нового покупця та вивід повного списка покупців
            buyerService.AddBuyer();
            buyerService.OutputBuyers();

            //Додавання нового робітника та вивід повного списка робітників
            employeeService.AddEmployee();
            employeeService.OutputEmployees();

            //Додавання нової покупки та вивід повного списка покупок
            purchaseService.AddPurchase();
            purchaseService.OutputPurchase();

            //Робота зі списком продуктів
            productsService.DeleteProductByID(10); //видалення продукту за неіснуючім ID
            productsService.DeleteProductByID(2);  //видалення продукту за існуючім ID
            productsService.GetProductByID(10);   //Отримання продукту за неіснуючім ID
            productsService.GetProductByID(1);    //Отримання продукту за існуючім ID

        }
    }
}
