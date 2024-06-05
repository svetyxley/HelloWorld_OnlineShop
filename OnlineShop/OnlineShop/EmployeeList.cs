using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class EmployeeList
    {
        public ListController<Employee> employeeList;

        public EmployeeList()
        {
            employeeList = new ListController<Employee>();
        }
        public void AddUser(Employee employee)
        {
            employeeList.AddItem(employee);
        }

        public bool RemoveUserID(int index)
        {
            return employeeList.RemoveItemAt(index);
        }

        public List<Employee> GetUser()
        {
            return employeeList.GetItems();
        }
        public override string ToString()
        {
            return employeeList.ToString();
        }
    }
}
