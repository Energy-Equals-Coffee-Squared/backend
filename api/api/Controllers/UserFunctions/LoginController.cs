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
        public async Task<ActionResult<IEnumerable<UsersDTO>>> LoginUser(string username, string password)
        {

            var users = await db.Users.Where(
                u => u.username.Equals(username) 
                && u.password.Equals(password)
                && u.isActive.Equals(true)
                && u.isDelted.Equals(false)
            ).Select(
                u => new UsersDTO()
                {
                    Id = u.Id,
                    username = u.username,
                    email = u.email,
                    first_name = u.first_name,
                    last_name = u.last_name,
                    contact_number = u.contact_number,
                    created_at = u.created_at,
                    updated_at = u.updated_at,
                    isAdmin = u.isAdmin
                }
            ).ToListAsync();

            if (users.Count == 0)
            {
                return NotFound();
            }

            return users;
        }

    }
}