namespace OnlineShop.Data.Entities
{
    public class DiscountCard
    {
        public int DiscountCard_ID { get; init; }
        public int buyerID { get; set; }
        public double PercanatageDiscount { get; set; }
        public DiscountCard()
        {

        }
        public DiscountCard(int discountCard_ID, double percanatageDiscount)
        {
            DiscountCard_ID = discountCard_ID;
            PercanatageDiscount = percanatageDiscount;
        }
        public DiscountCard(int discountCard_ID, int _buyerID, double percanatageDiscount)
        {
            DiscountCard_ID = discountCard_ID;
            buyerID = _buyerID;
            PercanatageDiscount = percanatageDiscount;
        }
        public override string ToString()
        {
            return $"Discount card ID: {DiscountCard_ID}, Buyer: {buyerID}, Percantage Discount: {PercanatageDiscount}";
        }
    }
}