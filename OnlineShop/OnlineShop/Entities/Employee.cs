using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    public class Employee : User
    {
        public double Salary { get; set; }
        public string Position { get; set; }
        public Employee()
        {

        }
        public Employee(int userID, int inn, string name, string surname)
        {
            UserID = userID;
            INN = inn;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"EmployeeID: {UserID}, Employee INN: {INN}, Employee name: {Name}, Employee surname: {Surname}";
        }
    }
}
