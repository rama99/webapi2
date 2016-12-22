using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using webAPI2.Models;
using webAPI2.ViewModel;

namespace webAPI2.BAL
{
    public class Emp
    {
        public static void AddEmployee(webAPI2.ViewModel.Employee employee)
        {
            using(company entities = new company())
            {
                webAPI2.Models.Employee objEmployee = new webAPI2.Models.Employee();

                objEmployee.FirstName = employee.FirstName;
                objEmployee.LastName = employee.LastName;
                objEmployee.DeptID = employee.DeptID;

                entities.Employees.Add(objEmployee);
                entities.SaveChanges();
            }
        }

        public static List<webAPI2.ViewModel.Employee> GetAllEmployees()
        {
            using(company entities = new company())
            {
                return entities.Employees.Select(emp => new webAPI2.ViewModel.Employee() { EmpID = emp.EmpID, DeptID = emp.DeptID, FirstName = emp.FirstName, LastName = emp.LastName } ).ToList();
            }
        }
    }
}