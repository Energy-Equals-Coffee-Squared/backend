using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Helpers;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CoffeeContext db;

        public UsersController(CoffeeContext context)
        {
            db = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await db.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await db.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // POST: api/Users/Login
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UsersDTO>> LoginUser(string username, string password)
        {

            var users = await db.Users.Where(
                u => u.username.Equals(username)
                && u.password.Equals(Encryption.HashPassword(password))
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
            ).FirstOrDefaultAsync();

            if (users == null)
            {
                return new JsonResult(new { Status = "error", Message = "Username or Password is incorrect"});
            }
            return new JsonResult(new { Status = "success", Message = users });
        }

        // POST: api/Users/Register
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<UsersDTO>> RegisterUser(
            string inUsername, string inEmail,
            string inFirst_name, string inLast_name,
            string inPassword, string inContact_number
            )
        {
            if (isUsernameTaken(inUsername))
            {
                return new JsonResult(new { Status = "error", Message = "Username is taken" });
            }

            if (isEmailTaken(inEmail))
            {
                return new JsonResult(new { Status = "error", Message = "Email is taken" });
            }

            Users users = new Users
            {
                username = inUsername,
                email = inEmail,
                first_name = inFirst_name,
                last_name = inLast_name,
                password = Encryption.HashPassword(inPassword),
                contact_number = inContact_number,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                isActive = true,
                isDelted = false,
                isAdmin = false
            };
            db.Users.Add(users);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new JsonResult(new { Status = "error", Message = "An error has occured"});
            }

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
            return new JsonResult(new { Status = "success", Message = userDTO });
        }

        // POST: api/Users/Login
        [Route("Delete")]
        [HttpPost]
        public async Task<ActionResult<UsersDTO>> DeleteUser(int id)
        {

            var users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            users.isDelted = true;

            db.Users.Update(users);
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

        private bool isUsernameTaken(string username)
        {
            return db.Users.Any(e => e.username == username);
        }

        private bool isEmailTaken(string email)
        {
            return db.Users.Any(e => e.email == email);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Any(e => e.Id == id);
        }
    }
}
