using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    public class Buyer : User
    {
        public Buyer()
        {

        }
        public Buyer(int userID, int inn, string name, string surname)
        {
            UserID = userID;
            INN = inn;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"BuyerID: {UserID}, buyer INN: {INN}, buyer name: {Name}, buyer surname: {Surname}";
        }
    }
}
