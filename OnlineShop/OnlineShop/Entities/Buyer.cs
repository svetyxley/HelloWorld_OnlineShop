using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data;


namespace OnlineShop.Data.Entities
{
    public class Buyer : User
    {

        public required int BuyerId { get; set; }

        public string BuyerEmail { get; set; }

        //public int DiscountCardId { get; set; }


        public Buyer()
        {
            BuyerId = JsonController<Buyer>.LoadIndexer();
        }

        public Buyer( string email, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)
                                         : base(inn, name, surname, phoneNumber, userBirthDate, address)
        {
            BuyerId = JsonController<Buyer>.LoadIndexer();

            BuyerEmail = email;
            //DiscountCardId = discountCardId;
        }

        public override string ToString()
        {
            return $"BuyerId: {this.BuyerId} {base.ToString()}  email: {this.BuyerEmail}";
        }


    }

}
