﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Constants;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class EmployeeService
    {
        private InputManager _inputManager = new();
        private InputValidator _inputValidator = new();
        private OutputManager _outputManager = new();
        private IDGenerator _generatorID = new();
        private CommonEntityService<Employee> _commonEntityService = new();

        private List<Employee> employees = new List<Employee>()
        {
           new(1, 34894, "EmployeeName1", "EmployeeSurName1"),
           new(2, 34314, "EmployeeName2", "EmployeeSurName2")
        };
        public Employee CreateEmployee()
        {
            int userID = _generatorID.InputID(employees);
            int inn = _inputManager.InputINN(_inputValidator, _commonEntityService.GetListType());
            string name = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            string surname = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            return new Employee(userID, inn, name, surname);
        }
        public void AddEmployee()
        {
            employees.Add(CreateEmployee());
            _outputManager.Write(NotificationConstants.ADDED, _commonEntityService.GetListType());
        }
        public void RemoveemployeeID(int employeeID)
        {
            var employee = employees.FirstOrDefault(employee => employee.UserID == employeeID);
            if (employee != null)
            {
                employees.Remove(employee);
                _outputManager.Write(NotificationConstants.DELETED, _commonEntityService.GetListType());
            }
            else
            {
                _outputManager.Write(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
        }
        public User Updatebuyer(int employeeID)
        {
            var employee = employees.FirstOrDefault(employee => employee.UserID == employeeID);
            if (employee == null)
            {
                _outputManager.Write(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return employee;
        }
        public Employee GetEmployeeByID()
        {
            var employeeID = _inputManager.InputID(_inputValidator, _commonEntityService.GetListType());
            var employee = employees.FirstOrDefault(employee => employee.UserID == employeeID);
            if (employee == null)
            {
                _outputManager.Write(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return employee;
        }
        public void OutputEmployees()
        {
            _outputManager.Write(_commonEntityService.OutputList(employees), _commonEntityService.GetListType());
        }
    }
}
