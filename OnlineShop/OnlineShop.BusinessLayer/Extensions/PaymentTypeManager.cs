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

            // присваеваем проверенное имя свойству PaymentType_Name
            paymentType.PaymentType_Name = PaymnetTypeName;
        }
    }
}
