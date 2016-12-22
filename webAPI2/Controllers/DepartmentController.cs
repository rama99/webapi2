using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using webAPI2.BAL;
using webAPI2.Models;
using webAPI2.ViewModel;

namespace webAPI2.Controllers
{
    //[EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DepartmentController : ApiController
    {
        // All Depts
        public IHttpActionResult Get()
        {            
            List<webAPI2.ViewModel.Dept> depts = webAPI2.BAL.Dept.GetDepartments().Select(dept => new webAPI2.ViewModel.Dept   { DeptID = dept.DeptID, DeptName = dept.DeptName }).ToList();
            return Ok(depts);
        }

        [Route("Department/{DeptID:int}/Employees")]
        //[Route("{DeptID:int}/details")]
        public IHttpActionResult Get(int DeptID)
        {
            List<webAPI2.ViewModel.Employee> emps = webAPI2.BAL.Dept.GetEmployeesByDept(DeptID);
            return Ok(emps);
        }

        public IHttpActionResult Post(webAPI2.ViewModel.Dept dept)
        {
            webAPI2.BAL.Dept.CreateDepartment(dept);
            return Ok("{ }");
        }

        public IHttpActionResult Put()
        {
            return Ok();
        }

        public IHttpActionResult Delete()
        {
            return Ok();
        }
    }
}
