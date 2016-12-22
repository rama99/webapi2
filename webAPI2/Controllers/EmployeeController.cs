using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using webAPI2.ViewModel;
using webAPI2.BAL;

namespace webAPI2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<webAPI2.ViewModel.Employee> employees = webAPI2.BAL.Emp.GetAllEmployees();
            return Ok(employees);
        }

        public IHttpActionResult Post(webAPI2.ViewModel.Employee employee)
        {
            webAPI2.BAL.Emp.AddEmployee(employee);
            return Ok();
        }


    }
}
