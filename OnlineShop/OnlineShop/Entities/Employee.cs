using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;

namespace OnlineShop.Data.Entities
{
    public class Employee : User
    {
        public required int EmployeeId {  get; set; }    

        public double Salary { get; set; }
        public string Position { get; set; }

        public DateOnly HireDate { get; set; }

        public Employee()
        {
            EmployeeId = JsonController<Employee>.LoadIndexer();
        }
        public Employee( ulong inn, string name, string surname)
        {
            EmployeeId = JsonController<Employee>.LoadIndexer();
            INN = inn;
            Name = name;
            Surname = surname;
        }

        public Employee( string position, DateOnly hiredate, uint salary, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address) 
            : base (inn, name, surname, phoneNumber, userBirthDate, address)
        
        {
            EmployeeId = JsonController<Employee>.LoadIndexer();
            Position = position;
            HireDate = hiredate;
            Salary = salary;
            
        }

        public override string ToString()
        {
            return $"EmployeeID: {EmployeeId}, Employee INN: {INN}, Employee name: {Name}, Employee surname: {Surname}, Salary: {Salary}, Position:{Position}";
        }
    }
}
