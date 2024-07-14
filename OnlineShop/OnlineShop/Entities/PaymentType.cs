using OnlineShop.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Entities
{
    public class PaymentType
    {

        public required int PaymentType_Id { get; set; }

        public string PaymentType_Name { get; set; }


        public PaymentType()
        {
            PaymentType_Id = JsonController<PaymnetTypes>.LoadIndexer();
        }

        public PaymentType( int id, string name)
        {
            PaymentType_Id = JsonController<PaymnetTypes>.LoadIndexer();
            PaymentType_Name = name;
        }


        public override string ToString()
        {
            return PaymentType_Name;
        }

    }
}
