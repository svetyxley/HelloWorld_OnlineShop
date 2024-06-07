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
        private static int indexer = 0;

        private int BuyerId {  get; set; }

        private MailAddress BuyerEmail { get; set; } 

        //public int DiscountCardId { get; set; }


        public Buyer()
        {
            BuyerId = indexer;
            indexer++;
        }

        public Buyer( MailAddress email, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)
            : base ( inn, name, surname, phoneNumber, userBirthDate, address)
        {

            BuyerId = indexer;
            indexer++;

            BuyerEmail = email;
            //DiscountCardId = discountCardId;
        }

        public override string ToString()
        {
            return $"BuyerId: {this.BuyerId} {base.ToString()}  email: {this.BuyerEmail}";
        }
    }
}
