using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserServiceReference;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        Service1Client sc = new Service1Client();

        // POST: api/Login
        //[HttpPost]
        //public void Login(string username, string password)
        //{
        //    UserDetails user = sc.LoginUserAsync(username, password).Result;
        //}

        [HttpPost]
        public string[] get(string username, string password)
        {
            UserDetails user = sc.LoginUserAsync(username, password).Result;

            if(user == null)
            {
                return new string[] { };
            }
            else
            {
                return new string[] {user.first_name, user.last_name, user.id+""};
            }
        }
    }
}
