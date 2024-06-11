using OnlineShop.Constants;
using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EntityServices
{
    public class BuyerService
    {
        private InputManager _inputManager = new();
        private InputValidator _inputValidator = new();
        private OutputManager _outputManager = new();
        private IDGenerator _generatorID = new();
        private CommonEntityService<Buyer> _commonEntityService = new();

        private List<Buyer> buyers = new List<Buyer>()
        {
           new(1, 34334, "BuyerName1", "BuyerSurName1"),
           new(2, 34634, "BuyerName2", "BuyerSurName2")
        };
        public Buyer CreateBuyer()
        {
            int userID = _generatorID.InputID(buyers);
            int inn = _inputManager.InputINN(_inputValidator, _commonEntityService.GetListType());
            string name = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            string surname = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            return new Buyer(userID, inn, name, surname);
        }
        public void AddBuyer()
        {
            buyers.Add(CreateBuyer());
            _outputManager.Write(NotificationConstants.ADDED, _commonEntityService.GetListType());
        }
        public void RemoveBuyerID(int buyerID)
        {
            var buyer = buyers.FirstOrDefault(buyer => buyer.UserID == buyerID);
            if (buyer != null)
            {
                buyers.Remove(buyer);
                _outputManager.Write(NotificationConstants.DELETED, _commonEntityService.GetListType());
            }
            else
            {
                _outputManager.Write(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
        }
        public Buyer Updatebuyer(int buyerID)
        {
            var buyer = buyers.FirstOrDefault(buyer => buyer.UserID == buyerID);
            if (buyer == null)
            {
                _outputManager.Write(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return buyer;
        }
        public Buyer GetManufacturerByID()
        {
            var buyerID = _inputManager.InputID(_inputValidator, _commonEntityService.GetListType());
            var buyer = buyers.FirstOrDefault(buyer => buyer.UserID == buyerID);
            if (buyer == null)
            {
                _outputManager.Write(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return buyer;
        }
        public void OutputBuyers()
        {
            _outputManager.Write(_commonEntityService.OutputList(buyers), _commonEntityService.GetListType());
        }
    }
}
