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
        private DapperContext dapperContext = new();
        private List<DiscountCard> discountCard = new List<DiscountCard>();

        public async Task<DiscountCard> CreateCard(double discountPercantage, string connectionStr)
        {
            try
            {
                //buyerID = idGenerator.InputID(discountCard);
                var connection = dapperContext.OpenConnection(connectionStr);

                discountPercantage = inputManager.InputDiscountPercantage(inputValidator, commonEntityService.GetListType());
                return new DiscountCard(buyerService.GetManufacturerByID().BuyerId, discountPercantage);
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        //public async Task AddCard(int cardID, double discountPercantage)
        //{
        //    discountCard.Add(await CreateCard(cardID, discountPercantage));
        //    outputManager.OutputToConsole(NotificationConstants.CARD_IS_SUCESSFULLY_ADDED, commonEntityService.GetListType());
        //}
        public async Task<DiscountCard> UpdateCard(int cardID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                cardID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
                var card = discountCard.FirstOrDefault(discountCard => discountCard.DiscountCard_ID == cardID);
                if (card == null)
                {
                    outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
                }
                return card;
            }
            catch(Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public void OutputDiscountCards(string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                outputManager.OutputToConsole(commonEntityService.OutputList(discountCard), commonEntityService.GetListType());
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task<DiscountCard> GetDiscountCardByID(int cardID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
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
            catch( Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
    }
}