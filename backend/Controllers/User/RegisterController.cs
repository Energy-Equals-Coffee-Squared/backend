using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserServiceReference;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        Service1Client sc = new Service1Client();

        // POST: api/Register
        [HttpPost]
        public void Register(string username, string email, string password, string rptPassword,
            string first_name, string last_name, string contact_number)
        {
            bool register = sc.RegisterUserAsync(username, email, password, rptPassword, first_name, last_name, contact_number).Result;
            if (register)
            {

            }
            else
            {

            }
        }
    }
}
