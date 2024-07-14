using OnlineShop.Data;
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


            string buyerEmail;
            if(!InputCheck.GetEmail(email,out buyerEmail)) { return; }

            string Name;
            if(!InputCheck.GetString(name,out Name)) { return; }

            string Surname;
            if(!InputCheck.GetString(surname,out Surname)) { return; }

            string PhoneNumber;
            if(!InputCheck.GetPhoneNumber(phoneNumber,out PhoneNumber)) { return; }

            ulong INN;
            if(!InputCheck.GetINN(inn,out INN)) { return; }

            string Address;
            if(!InputCheck.GetString(address,out Address)) { return; }


            DateOnly UserBirthDate;
            if(!InputCheck.GetDataOnly(userBirthDate,out UserBirthDate)) { return; }

            buyer.BuyerEmail = buyerEmail;
            buyer.Name = Name;
            buyer.Surname = Surname;
            buyer.PhoneNumber = PhoneNumber;
            buyer.INN = INN;
            buyer.Address = Address;
            buyer.UserBirthDate = UserBirthDate;
        }
    }
}
