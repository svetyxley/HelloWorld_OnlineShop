using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.EntityServices;
using OnlineShop.BusinessLayer.Validators;

namespace OnlineShop.BusinessLayer.Services
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
            return new DiscountCard(cardID, buyerService.GetManufacturerByID().BuyerId, discountPercantage);
        }
        public void AddCard()
        {
            discountCard.Add(CreateCard());
            outputManager.OutputToConsole(NotificationConstants.ADDED, commonEntityService.GetListType());
        }
        public DiscountCard UpdateCard()
        {
            var cardID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var card = discountCard.FirstOrDefault(discountCard => discountCard.DiscountCard_ID == cardID);
            if (card == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return card;
        }
        public void OutputDiscountCards()
        {
            outputManager.OutputToConsole(commonEntityService.OutputList(discountCard), commonEntityService.GetListType());
        }
        public DiscountCard GetDiscountCardByID()
        {
            var cardID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            var card = discountCard.FirstOrDefault(discountCard => discountCard.DiscountCard_ID == cardID);
            if (card == null)
            {
                outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            else
            {
                outputManager.OutputToConsole(card.ToString(), commonEntityService.GetListType());
            }
            return card;
        }
    }
}