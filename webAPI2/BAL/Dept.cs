using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAPI2.Models;
using webAPI2.ViewModel;

namespace webAPI2.BAL
{
    public class Dept
    {
        public static List<Department> GetDepartments()
        {
            using(company entities = new company())
            {
                entities.Configuration.LazyLoadingEnabled = false;
                return entities.Departments.Where(dept => dept.IsActive == true).ToList();
                //.Select(dept => { dept.DeptID , dept.DeptName });
            }
        }

        public static Department GetDepartmentByID(int id)
        {
            using(company entities = new company())
            {
                return entities.Departments.Find(id);
            }
        }

        public static List<webAPI2.ViewModel.Employee> GetEmployeesByDept(int DeptID)
        {
            using(company entities = new company())
            {
                return entities.Employees.Where(emp => emp.DeptID == DeptID).Select(emp => new webAPI2.ViewModel.Employee { EmpID = emp.EmpID, DeptID = emp.DeptID, FirstName = emp.FirstName, LastName = emp.LastName }).ToList();
            }
        }

        public static void CreateDepartment(webAPI2.ViewModel.Dept dept)
        {
            using(company entities = new company())
            {
                webAPI2.Models.Department objDept = new Department() { DeptName = dept.DeptName, IsActive = true };
                objDept = entities.Departments.Add(objDept);
                entities.SaveChanges();
                // return 
            }
        }

        public static void UpdateDepartment()
        {

        }
    }
}