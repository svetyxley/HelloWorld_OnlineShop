using OnlineShop.Data;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.BusinessLayer.Managers;


namespace OnlineShop.BusinessLayer.Extensions
{
    public static class OrderManager
    {
        //public Order(int id, int supplierId, int productId, int employeeId, decimal productAmount, DateTime time)

        public static void AddDataToOrder (this Order order, string supplierId, string productId, string employeeId, string productAmount)
        {


            //supplierId
            int idOfSupplier;
            if (!InputCheck.GetIdNumber(supplierId,out idOfSupplier)) { return; }
            //проверка такого id в базе
            if (JsonController<Supplier>.checkId(idOfSupplier))
            {
                order.SupplierId = idOfSupplier;
            }
            else { InputCheck.ShowError("Нет такого supplierId"); }

            //productId
            int idOfProduct;
            if (!InputCheck.GetIdNumber(productId,out idOfProduct)) { return; }
            //проверка такого id в базе
            if (JsonController<Product>.checkId(idOfProduct))
            {
                order.ProductId = idOfProduct;
            }
            else { InputCheck.ShowError("Нет такого productId"); }

            //employeeId
            int idOfEmployee;
            if(!InputCheck.GetIdNumber(employeeId,out idOfEmployee)) { return; }
            //проверка такого id в базе
            if (JsonController<Employee>.checkId(idOfEmployee))
            {
                order.EmployeeId = idOfEmployee;
            }
            else { InputCheck.ShowError("Нет такого employeeId"); }

            decimal productAmountD;
            if (!InputCheck.GetAmountDecimal(productAmount, out productAmountD)){ return; }

            order.ProductAmount = productAmountD;

            //OrderId
            order.OrderId = JsonController<Order>.LoadIndexer();
            JsonController<Order>.SaveIndexer(order.OrderId + 1);



            order.OrderTime = DateTime.Now;
        }

    }
}
