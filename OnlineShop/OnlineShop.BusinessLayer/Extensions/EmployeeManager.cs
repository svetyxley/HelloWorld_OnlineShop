using OnlineShop.Data;
using OnlineShop.Data.Entities;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Managers;


namespace OnlineShop.BusinessLayer.Extensions
{
    static class EmployeeManager
    {
        public static void addDataToEmployee(this Employee employee, string position, string hiredate, string salary, string inn, string name, string surname, string phoneNumber, string userBirthDate, string address)
        {
            //public Employee(int employeeId, string position, DateOnly hiredate, uint salary, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)


            string nameRes = string.Empty;
            if(!InputCheck.GetString(name,out nameRes)) { return; }
            employee.Name = nameRes;

            string surnameRes = string.Empty;
            if(!InputCheck.GetString(surname, out surnameRes)) { return; }
            employee.Surname = surnameRes;

            string phoneNumberRes;
            if(!InputCheck.GetPhoneNumber(phoneNumber, out phoneNumberRes)) { return; }
            employee.PhoneNumber = phoneNumberRes;

            ulong innResult;
            if(!InputCheck.GetINN(inn, out innResult)) { return; }
            employee.INN = innResult;

            string adr = string.Empty;
            if(!InputCheck.GetString(address, out adr)) { return; }
            employee.Address = adr;

            DateOnly birthDay;
            if(!InputCheck.GetDataOnly(userBirthDate,out birthDay)) {  return; }
            employee.UserBirthDate = birthDay;

            DateOnly hireDay;
            if(!InputCheck.GetDataOnly(hiredate, out hireDay)) {  return; }
            employee.HireDate = hireDay;

            uint salaryResult;
            if(!InputCheck.GetPriceUint(salary,out salaryResult)) {  return; }
            employee.Salary = salaryResult;

            string pos = string.Empty;
            if(!InputCheck.GetString(address,out pos)) { return; }
            employee.Position = pos;


            employee.EmployeeId = JsonController<Employee>.LoadIndexer();
            JsonController<Employee>.SaveIndexer(employee.EmployeeId + 1);
        }
    }
}
