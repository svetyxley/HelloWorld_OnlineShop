using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Constants;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class UserService
    {
        private InputManager _inputManager = new();
        private InputValidator _inputValidator = new();
        private OutputManager _outputManager = new();
        private IDGenerator _generatorID = new();
        private CommonEntityService<User> _commonEntityService = new();
        
        private List<User> users = new List<User>()
        {
           new(1, 34334, "UserName1", "UserSurName1"),
           new(2, 34634, "UserName2", "UserSurName2"),
           new(3, 34894, "UserName3", "UserSurName3"),
           new(4, 34314, "UserName4", "UserSurName4")
        };
        public User CreateUser()
        {
            int userID = _generatorID.InputID(users);
            int inn = _inputManager.InputINN(_inputValidator, _commonEntityService.GetListType());
            string name = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            string surname = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            return new User(userID, inn, name, surname);
        }
        public void AddUser()
        {
            users.Add(CreateUser());
            _outputManager.OutputToConsole(NotificationConstants.ADDED, _commonEntityService.GetListType());
        }
        public void RemoveUserID(int userID)
        {
            var user = users.FirstOrDefault(user => user.UserID == userID);
            if (user != null)
            {
                users.Remove(user);
                _outputManager.OutputToConsole(NotificationConstants.DELETED, _commonEntityService.GetListType());
            }
            else
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
        }
        public User UpdateUser(int userID)
        {
            var user = users.FirstOrDefault(user => user.UserID == userID);
            if (user == null)
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return user;
        }
        public User GetManufacturerByID(int userID)
        {
            var user = users.FirstOrDefault(user => user.UserID == userID);
            if (user == null)
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return user;
        }
        public void OutputUsers()
        {
            _outputManager.OutputToConsole(_commonEntityService.OutputList(users), _commonEntityService.GetListType());
        }
    }
}
