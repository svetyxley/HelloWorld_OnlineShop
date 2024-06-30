using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.Extensions
{
    public static class PaymentTypeManager
    {

        public static void AddDataToPaymnetType( this PaymentType paymentType, string paymentName)
        {
            string PaymnetTypeName = string.Empty;
            if (!InputCheck.GetString(paymentName, out PaymnetTypeName)) { return; }

            //присваиваем id и записываем в json id на 1 больше
            paymentType.PaymentType_Id = JsonController<PaymentType>.LoadIndexer();
            JsonController<PaymentType>.SaveIndexer(paymentType.PaymentType_Id + 1);

            // присваеваем проверенное имя свойству PaymentType_Name
            paymentType.PaymentType_Name = PaymnetTypeName;
        }
    }
}
