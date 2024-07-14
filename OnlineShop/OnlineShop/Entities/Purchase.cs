using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;

namespace OnlineShop.Data.Entities
{
    public class Purchase
    {
        public  required int PurchaseId { get; set; }
        public int BuyerId { get; set; }

        public int EmployeeId { get; set; }

        public int OrderDetailsId { get; set; }

        public DateTime PurchaseTime { get; set; }

        private Buyer _buyer;
        private Employee _employee;

        public Purchase()
        {
            PurchaseId = JsonController<Purchase>.LoadIndexer();
        }

        public override string ToString()
        {
            return $"PurchaseID: {PurchaseId}, buyerID: {BuyerId}, PurchaseTime: {PurchaseTime} and productID: {_productID}";
        }
    }
}
