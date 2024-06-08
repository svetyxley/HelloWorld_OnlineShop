using OnlineShop.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    public class Buyer : User
    {

        public int BuyerId {  get; set; }

        public string BuyerEmail { get; set; } 

        //public int DiscountCardId { get; set; }


        public Buyer()
        {
            
        }

        public Buyer(int Id, string email, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)
                                         : base ( inn, name, surname, phoneNumber, userBirthDate, address)
        {
            BuyerId = Id;

            BuyerEmail = email;
            //DiscountCardId = discountCardId;
        }

        public override string ToString()
        {
            return $"BuyerId: {this.BuyerId} {base.ToString()}  email: {this.BuyerEmail}";
        }
    }
}
