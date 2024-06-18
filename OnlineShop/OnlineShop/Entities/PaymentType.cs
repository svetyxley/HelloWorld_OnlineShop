using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    public class PaymentType
    {

        public int PaymentType_Id { get; private set; }

        public string PaymentType_Name { get; set; }

        public PaymentType()
        {

        }

        public PaymentType( int id, string name)
        {
            PaymentType_Id = id;
            PaymentType_Name = name;
        }

        public override string ToString()
        {
            return PaymentType_Name;
        }

    }
}
