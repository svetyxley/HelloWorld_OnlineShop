using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class Review
    {
        public int PaymentType_Id;
        public paymnetTypes paymnetType;

        public Review()
        {
                
        }


    }

    enum paymnetTypes
    {
        cash_on_delivery,
        on_bank_account,
        by_card_transfer
    }
}
