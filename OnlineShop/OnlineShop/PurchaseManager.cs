using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class PurchaseManager
    {
        public ListController<Purchase> purchaseList;

        public PurchaseManager()
        {
            purchaseList = new ListController<Purchase>();
        }


    }
}
