﻿using OnlineShop.Data;
using OnlineShop.Data.Entities;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShop.BusinessLayer.Extensions
{
    public static class BuyerManager
    {
        public static void addDataToBuyer(this Buyer buyer, string email, string inn, string name, string surname, string phoneNumber, string userBirthDate, string address)
        {
            buyer.BuyerId = JsonController<Buyer>.LoadIndexer();
            JsonController<Buyer>.SaveIndexer(buyer.BuyerId + 1);

            buyer.BuyerEmail = InputCheck.GetEmail(email);
            buyer.Name = InputCheck.GetString(name);
            buyer.Surname = InputCheck.GetString(surname);
            buyer.PhoneNumber = InputCheck.GetPhoneNumber(phoneNumber);
            buyer.INN = InputCheck.GetINN(inn);
            buyer.Address = InputCheck.GetString(address);
            buyer.UserBirthDate = InputCheck.GetDataOnly(userBirthDate);
        }
    }
}
