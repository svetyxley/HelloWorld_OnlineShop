using OnlineShop.BusinessLayer.Extensions;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.EntityServices;
using OnlineShop.Records;

namespace OnlineShop
{
    public class ProductsCatalogFlow
    {
        public void CatalogProcesses()
        {
            ProductsService productsService = new ProductsService();
            ManufacturesService manufactureService = new ManufacturesService();
            SuppliersService suppliersService = new SuppliersService(new DapperContext(), new ActivityLogService(), new OutputManager());
            PurchaseService purchaseService = new PurchaseService();
            EmployeeService employeeService = new EmployeeService();
            BuyerService buyerService = new BuyerService();
            UserService userService = new UserService();
            OrderSupplyService orderSupplyService = new OrderSupplyService();
            DiscountCardService discountCardService = new DiscountCardService();

            //Створення дисконтної картки та вивід усіх карток
            discountCardService.AddCard();
            discountCardService.OutputDiscountCards();

            //Замовлення поставки та вивід усіх замовлень поставок
            orderSupplyService.AddOrder();
            orderSupplyService.OutputSupplyOrders();

            //Додавання нового виробника та вивід повного списка виробників
            manufactureService.AddToManufacturers();
            manufactureService.OutputManufacturers();

            //Додавання нового виробника та вивід повного списка постачальників
 //           suppliersService.AddToSuppliers();
//            suppliersService.OutputSuppliers();

            //Додавання нового продукту та вивід повного списка продуктів
            productsService.CountChecker(); // extension method
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
            productsService.DeleteProductByID(); //видалення продукту за неіснуючім ID
            productsService.GetProductByID();   //Отримання продукту за неіснуючім IDID
        }
    }
}