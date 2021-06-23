using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webapi_consume_webforms.Controllers
{
    public class EmpDetailsController : ApiController
    {
        public IHttpActionResult getempdetails()
        {
            EmployeeDBEntities sd = new EmployeeDBEntities();
            var results = sd.Employees.ToList();
            return Ok(results);
        }
    }
}
