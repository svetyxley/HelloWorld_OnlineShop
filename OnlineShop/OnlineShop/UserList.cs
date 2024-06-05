using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class UserList
    {
        public ListController<User> userList;

        public UserList()
        {
            userList = new ListController<User>();
        }
        public void AddUser(User user)
        {
            userList.AddItem(user);
        }

        public bool RemoveUserID(int index)
        {
            return userList.RemoveItemAt(index);
        }

        public List<User> GetUser()
        {
            return userList.GetItems();
        }
        public override string ToString()
        {
            return userList.ToString();
        }
    }
}
