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
        public async Task<ActionResult<UsersDTO>> RegisterUser(
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
                isDelted = false,
                isAdmin = false
            };
            db.Users.Add(users);
            await db.SaveChangesAsync();

            UsersDTO userDTO = new UsersDTO
            {
                Id = users.Id,
                username = users.username,
                email = users.email,
                first_name = users.first_name,
                last_name = users.last_name,
                contact_number = users.contact_number,
                created_at = users.created_at,
                updated_at = users.updated_at,
                isAdmin = users.isAdmin
            };

            return userDTO;
        }
    }
}