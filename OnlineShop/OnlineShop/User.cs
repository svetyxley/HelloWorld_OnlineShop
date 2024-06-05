using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class User
    {
        public int UserID { get; set; }
        public int INN { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User()
        {

        }
        public User(int userid, int inn, string name, string surname)
        {
            UserID = userid;
            INN = inn;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"UserID: {UserID}, user name: {Name}, user surname {Surname}";
        }
    }
}
