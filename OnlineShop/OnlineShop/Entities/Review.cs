using OnlineShop.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Entities
{
    internal class Review
    {
        public required int Review_Id;
        public PaymnetTypes paymnetType;
        public OrderMark orderMark;
        public string Review_Description;

        public Review()
        {
            Review_Id = JsonController<Review>.LoadIndexer();
        }


        public Review(PaymnetTypes paymnetType, OrderMark orderMark, string Review_Description)
        {
            Review_Id = JsonController<Review>.LoadIndexer();
            this.paymnetType = paymnetType;
            this.orderMark = orderMark;
            this.Review_Description = Review_Description;
        }


    }

    enum PaymnetTypes
    {
        cash_on_delivery,
        on_bank_account,
        by_card_transfer
    }

    enum OrderMark
    {
        very_bad,
        bad,
        normal,
        good,
        excelent
    }
}
