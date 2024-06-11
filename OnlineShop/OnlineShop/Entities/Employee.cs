using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    public class Employee : User
    {
        public int EmployeeId {  get; set; }    

        public double Salary { get; set; }
        public string Position { get; set; }

        public DateOnly HireDate { get; set; }

        public uint Salary { get; set; }


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

        public Employee(int employeeId, string position, DateOnly hiredate, uint salary, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address) 
            : base (inn, name, surname, phoneNumber, userBirthDate, address)
        
        {
            EmployeeId = employeeId;    
            Position = position;
            HireDate = hiredate;
            Salary = salary;
            
        }

        public override string ToString()
        {
            return $"EmployeeID: {UserID}, employee INN: {INN}, employee name: {Name}, employee surname: {Surname}";
        }
    }
}
