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

        //string position;
        //    if (!GettingData.GetString(positionTextBox, out position)) { return; }

        public static void addDataToBuyer(this Buyer buyer, string email, string inn, string name, string surname, string phoneNumber, string userBirthDate, string address)
        {
            buyer.BuyerId = JsonController<Buyer>.LoadIndexer();
            JsonController<Buyer>.SaveIndexer(buyer.BuyerId + 1);

            string buyerEmail = InputCheck.GetEmail(email);
            string Name = InputCheck.GetString(name);
            string Surname = InputCheck.GetString(surname);
            string PhoneNumber = InputCheck.GetPhoneNumber(phoneNumber);
            ulong INN = InputCheck.GetINN(inn);
            string Address = InputCheck.GetString(address);
            DateOnly UserBirthDate = InputCheck.GetDataOnly(userBirthDate);


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
