using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    internal class Order
    {
        private static int indexer = 0;

        public int OrderId { get; set; }

        public int SupplierId { get; set; }

        public int ProductId { get; set; }

        public decimal ProductAmount { get; set; }

        public DateTime OrderTime { get; set; }; 

        public int EmployeeId { get; set; }


        public Order()
        {
           this.OrderId = indexer;
           OrderTime = DateTime.Now;   
        }

        public Order(int supplierId, int productId, decimal productAmount, int employeeId)
        {
            this.OrderId = indexer;
            this.SupplierId = supplierId;
            this.ProductId = productId;
            this.ProductAmount = productAmount;
            OrderTime = DateTime.Now;
            this.EmployeeId = employeeId;
        }
    }
}
