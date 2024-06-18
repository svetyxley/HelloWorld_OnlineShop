using OnlineShop.Entities;
using OnlineShop.Constants;

namespace OnlineShop.EntityServices
{
    public class DiscountCardService
    {
        private InputManager inputManager = new();
        private OutputManager outputManager = new();
        private IDGenerator idGenerator = new();
        private InputValidator inputValidator = new();
        private CommonEntityService<DiscountCard> commonEntityService = new();
        private BuyerService buyerService = new();

        private List<DiscountCard> discountCard = new List<DiscountCard>()
        {
            new DiscountCard(1, 10),
            new DiscountCard(2, 15),
            new DiscountCard(3, 20)
        };

        public DiscountCard CreateCard()
        {
            int cardID = idGenerator.InputID(discountCard);
            double discountPercantage = inputManager.InputDiscountPercantage(inputValidator, commonEntityService.GetListType());
            return new DiscountCard(cardID, buyerService.GetManufacturerByID(), discountPercantage);
        }
        public void AddCard()
        {
            discountCard.Add(CreateCard());
            outputManager.Write(NotificationConstants.ADDED, commonEntityService.GetListType());
        }
        public DiscountCard UpdateCard()
        {
            var cardID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var card = discountCard.FirstOrDefault(discountCard => discountCard.DiscountCard_ID == cardID);
            if (card == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return card;
        }
        public void OutputDiscountCards()
        {
            outputManager.Write(commonEntityService.OutputList(discountCard), commonEntityService.GetListType());
        }
        public DiscountCard GetDiscountCardByID()
        {
            var cardID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var card = discountCard.FirstOrDefault(discountCard => discountCard.DiscountCard_ID == cardID);
            if (card == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            else
            {
                outputManager.Write(card.ToString(), commonEntityService.GetListType());
            }
            return card;
        }
    }
}