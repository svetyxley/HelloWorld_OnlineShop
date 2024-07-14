using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Entities
{
    public class PurchaseDetails
    {
        public required int PurchaseId { get; set; }
        
        public string ProductId { get; set; }

        public string ProductAmount {  get; set; }

    }
}
