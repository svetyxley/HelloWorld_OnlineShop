using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class Employee : User
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }


        public Employee()
        {

        }
        public Employee(int employeeID, int inn, string name, string surname)
        {
            EmployeeID = employeeID;
            INN = inn;
            EmployeeName = name;
            EmployeeSurname = surname;
        }

        public override string ToString()
        {
            return $"EmployeeID: {EmployeeID}, employee INN: {INN}, employee name: {EmployeeName}, employee surname: {EmployeeSurname}";
        }
    }
}
