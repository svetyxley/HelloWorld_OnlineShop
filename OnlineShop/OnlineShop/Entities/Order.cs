﻿using OnlineShop.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Entities
{
    public class Order
    {
        public required int OrderId { get; set; }

        public int SupplierId { get; set; }

        public int ProductId { get; set; }

        public int EmployeeId { get; set; }

        public decimal ProductAmount { get; set; }

        public DateTime OrderTime { get; set; } 



        public Order()
        {
            OrderId = JsonController<Order>.LoadIndexer();
        }

        public Order(int id, int supplierId, int productId, int employeeId, decimal productAmount, DateTime time)
        {
            OrderId = JsonController<Order>.LoadIndexer();
            this.SupplierId = supplierId;
            this.ProductId = productId;
            this.EmployeeId = employeeId;
            this.ProductAmount = productAmount;

            OrderTime = time;

        }
    }
}
