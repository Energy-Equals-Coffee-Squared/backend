using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers.UserFunctions
{
    [Route("api/Users/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CoffeeContext db;

        public LoginController(CoffeeContext context)
        {
            db = context;
        }
        // POST: api/Users/Login
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Users>>> PostUsers(string username, string password)
        {

            var users = await db.Users.Where(
                u => u.username.Equals(username) 
                && u.password.Equals(password)
                && u.isActive.Equals(true)
                && u.isDelted.Equals(false)).ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

    }
}