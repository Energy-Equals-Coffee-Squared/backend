using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Newtonsoft.Json;

namespace api.Controllers.UserFunctions
{
    [Route("api/Users/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly CoffeeContext db;

        public RegisterController(CoffeeContext context)
        {
            db = context;
        }

        // POST: api/Users/Register
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(
            string inUsername, string inEmail, 
            string inFirst_name, string inLast_name, 
            string inPassword, string inContact_number
            )
        {
            Users users = new Users
            {
                username = inUsername,
                email = inEmail,
                first_name = inFirst_name,
                last_name = inLast_name,
                password = inPassword,
                contact_number = inContact_number,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                isActive = true,
                isDelted = true,
                isAdmin = false
            };
            db.Users.Add(users);
            await db.SaveChangesAsync();
            var otuput = JsonConvert.SerializeObject(users);
            return otuput;
        }
    }
}