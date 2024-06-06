using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    internal class Employee : User
    {
        public string Position { get; set; }

        public DateOnly HireDate { get; set; }

        public int Salary { get; set; }


        public Employee()
        {
             
        }

        public Employee(string position, DateOnly hiredate, int salary)
        {
            Position = position;
            HireDate = hiredate;
            Salary = salary;
      
        }
    }
}
