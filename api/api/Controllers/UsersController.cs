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
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers(string search = "")
        {
            if (search == ""||search == null|| search == string.Empty)
            {
                return await db.Users.Where(u => u.isDelted.Equals(false)).ToListAsync();
            }
            else
            {
                return await db.Users.Where(u => u.isDelted.Equals(false) && (u.username.Contains(search) || u.last_name.Contains(search) || u.first_name.Contains(search) || u.email.Contains(search))).ToListAsync();

            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id, string search)
        {
            var users = await db.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }
        public async Task<IEnumerable<UsersDTO>> GetSearchUser(string search = "")
        {
            var users = db.Users.Select(
                u => new UsersDTO {
                    Id = u.Id,
                    username =u.username,
                    email = u.email,
                    first_name = u.first_name,
                    last_name = u.last_name,
                    contact_number = u.contact_number,
                    created_at = u.created_at,
                    updated_at = u.updated_at,
                    isAdmin = u.isAdmin,
                    isDeleted = u.isDelted,
                    isActive = u.isActive
                }
             );
            var searchUsers = users.Where(u => u.username.Contains(search)||u.last_name.Contains(search)||u.first_name.Contains(search)||u.email.Contains(search));

            var listUsers = searchUsers.ToListAsync();

            return await listUsers;
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

        // POST: api/Users/Login
        [Route("getNumberOfSignups")]
        [HttpGet]
        public async Task<ActionResult<UsersDTO>> getNumberOfSignups(string options)
        {
            DateTime toDate = DateTime.Now.AddDays(-1);
            //DateTime  One_Day = DateTime.Now.AddDays(-1);
            //DateTime  Two_Days = DateTime.Now.AddDays(-2);
            //DateTime  Three_Days = DateTime.Now.AddDays(-3);
            //DateTime  Four_Days = DateTime.Now.AddDays(-4);
            //DateTime  Five_Days = DateTime.Now.AddDays(-5);
            //DateTime  Six_Days = DateTime.Now.AddDays(-6);
            //DateTime  Seven_Days = DateTime.Now.AddDays(-7);

            switch (options)
            {
                case "day":
                    toDate = DateTime.Now.AddDays(-1);
                    DateTime One_Day = DateTime.Now.AddDays(-1);
                    DateTime Two_Days = DateTime.Now.AddDays(-2);
                    DateTime Three_Days = DateTime.Now.AddDays(-3);
                    DateTime Four_Days = DateTime.Now.AddDays(-4);
                    DateTime Five_Days = DateTime.Now.AddDays(-5);
                    DateTime Six_Days = DateTime.Now.AddDays(-6);
                    DateTime Seven_Days = DateTime.Now.AddDays(-7);

                    var query = db.Users.Where(u => u.created_at >= toDate && u.created_at <= DateTime.Now).Count();
                    var queryY = db.Users.Where(u => u.created_at >= One_Day && u.created_at <= DateTime.Now).Count();
                    var queryTwo = db.Users.Where(u => u.created_at >= Two_Days && u.created_at <= One_Day).Count();
                    var queryThree = db.Users.Where(u => u.created_at >= Three_Days && u.created_at <= Two_Days).Count();
                    var queryFour = db.Users.Where(u => u.created_at >= Four_Days && u.created_at <= Three_Days).Count();
                    var queryFive = db.Users.Where(u => u.created_at >= Five_Days && u.created_at <= Four_Days).Count();
                    var querySix = db.Users.Where(u => u.created_at >= Six_Days && u.created_at <= Five_Days).Count();
                    var querySeven = db.Users.Where(u => u.created_at >= Seven_Days && u.created_at <= Six_Days).Count();

                    return new JsonResult(new
                    {
                        numSignups = new
                        {
                            one = queryY,
                            two = queryTwo,
                            three = queryThree,
                            four = queryFour,
                            five = queryFive,
                            six = querySix,
                            seven = querySeven
                        },
                        option = options
                    });
                    break;

                case "week":
                    toDate = DateTime.Now.AddDays(-7);
                    DateTime WeekOne = DateTime.Now.AddDays(-7);
                    DateTime WeekTwo = DateTime.Now.AddDays(-14);
                    DateTime WeekThree = DateTime.Now.AddDays(-21);
                    DateTime WeekFour = DateTime.Now.AddDays(-28);
        
                    var queryWY = db.Users.Where(u => u.created_at >= WeekOne && u.created_at <= DateTime.Now).Count();
                    var queryWTwo = db.Users.Where(u => u.created_at >= WeekTwo && u.created_at <= WeekOne).Count();
                    var queryWThree = db.Users.Where(u => u.created_at >= WeekThree && u.created_at <= WeekTwo).Count();
                    var queryWFour = db.Users.Where(u => u.created_at >= WeekFour && u.created_at <= WeekThree).Count();


                    return new JsonResult(new
                    {
                        numSignups = new
                        {
                            Week_One = queryWY,
                            Week_Two = queryWTwo,
                            Week_Three = queryWThree,
                            Week_Four = queryWFour,
              
                        },
                        option = options
                    });

                    break;
                case "month":
                    toDate = DateTime.Now.AddMonths(-1);
                    DateTime Month_one = DateTime.Now.AddMonths(-1);
                    DateTime Month_Two = DateTime.Now.AddMonths(-2);
                    DateTime Month_Three = DateTime.Now.AddMonths(-3);
                    DateTime Month_Four = DateTime.Now.AddMonths(-4);
                    DateTime Month_Five = DateTime.Now.AddMonths(-5);
                    DateTime Month_Six = DateTime.Now.AddMonths(-6);
                    DateTime Month_Seven = DateTime.Now.AddMonths(-7);
                    DateTime Month_Eight = DateTime.Now.AddMonths(-8);
                    DateTime Month_Nine = DateTime.Now.AddMonths(-9);
                    DateTime Month_Ten = DateTime.Now.AddMonths(-10);
                    DateTime Month_Eleven = DateTime.Now.AddMonths(-11);
                    DateTime Month_Twelve = DateTime.Now.AddMonths(-12);

                    var MO = db.Users.Where(u => u.created_at >= Month_one && u.created_at <= DateTime.Now).Count();
                    var MT= db.Users.Where(u => u.created_at >= Month_one && u.created_at <= DateTime.Now).Count();
                    var MTH = db.Users.Where(u => u.created_at >= Month_Two && u.created_at <= Month_one).Count();
                    var MF = db.Users.Where(u => u.created_at >= Month_Three && u.created_at <= Month_Two).Count();
                    var MFV= db.Users.Where(u => u.created_at >= Month_Four && u.created_at <= Month_Three).Count();
                    var MS = db.Users.Where(u => u.created_at >= Month_Five && u.created_at <= Month_Four).Count();
                    var MSE = db.Users.Where(u => u.created_at >= Month_Six && u.created_at <= Month_Five).Count();
                    var ME = db.Users.Where(u => u.created_at >= Month_Seven && u.created_at <= Month_Six).Count();
                    var MN = db.Users.Where(u => u.created_at >= Month_Eight && u.created_at <= Month_Seven).Count();
                    var MTE = db.Users.Where(u => u.created_at >= Month_Nine && u.created_at <= Month_Eight).Count();
                    var MEL= db.Users.Where(u => u.created_at >= Month_Eleven && u.created_at <= Month_Nine).Count();
                    var MTW = db.Users.Where(u => u.created_at >= Month_Twelve && u.created_at <= Month_Eleven).Count();

                    return new JsonResult(new
                    {
                        numSignups = new
                        {
                            Month_One = MO,
                            Month_Two = MT,
                            Month_Three = MTH,
                            Month_Four = MF,
                            Month_Five = MFV,
                            Month_Six = MS,
                            Month_Seven = MSE,
                            Month_Eight = ME,
                            Month_Nine = MN,
                            Month_Ten = MT,
                            Month_Eleven = MEL,
                            Month_Twelve = MTW,

                        },
                        option = options
                    });

                    break;
                default:
                    return new JsonResult(new { Status = "error", Message = "Incorrect option of: "+ options });
            }

            //var query = db.Users.Where(u => u.created_at >= toDate && u.created_at <= DateTime.Now).Count() ;
            //var queryY = db.Users.Where(u => u.created_at >= One_Day && u.created_at <= DateTime.Now).Count();
            //var queryTwo = db.Users.Where(u => u.created_at >= Two_Days && u.created_at <= One_Day).Count();
            //var queryThree = db.Users.Where(u => u.created_at >= Three_Days && u.created_at <= Two_Days).Count();
            //var queryFour = db.Users.Where(u => u.created_at >= Four_Days && u.created_at <= Three_Days).Count();
            //var queryFive = db.Users.Where(u => u.created_at >= Five_Days && u.created_at <= Four_Days).Count();
            //var querySix = db.Users.Where(u => u.created_at >= Six_Days && u.created_at <= Five_Days).Count();
            //var querySeven = db.Users.Where(u => u.created_at >= Seven_Days && u.created_at <= Six_Days).Count();

            //return new JsonResult(new { numSignups = new { one = queryY,two = queryTwo, three = queryThree,
            //four = queryFour, five = queryFive, six = querySix, seven = querySeven}, option = options });
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
                isAdmin = users.isAdmin,
                isActive = users.isActive,
                isDeleted = users.isDelted
            };
            return new JsonResult(new { Status = "success", Message = userDTO });
        }

        // POST: api/Users/Delete
        [Route("Delete")]
        [HttpPost]
        public async Task<ActionResult<UsersDTO>> DeleteUser(int id)
        {

            var users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return new JsonResult(new { Status = "error", Message = "No user found with the id: "+id });
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
                isAdmin = users.isAdmin,
                isActive = users.isActive,
                isDeleted = users.isDelted
            };
            return userDTO;
        }

        [Route("Edit")]
        [HttpPost]
        public async Task<ActionResult<UsersDTO>> EdtUser(int Id, string username,
            string email,string f_name, string l_name,string c_number,
            int is_active, int is_deleted, int is_admin )
        {
            var user = await db.Users.Where(
                u => u.Id.Equals(Id)
            // && u.username.Equals(username)
            ).FirstOrDefaultAsync();

            if (!user.email.Equals(email) && isEmailTaken(email))
            {
                return new JsonResult(new { Status = "error", Message = "Eamil is taken" });
            }


            if (!user.username.Equals(username) && isUsernameTaken(username))
            {
                return new JsonResult(new { Status = "error", Message = "Username is taken" });
            }

            try
            {
                user.username = username;
                user.first_name = f_name;
                user.last_name = l_name;
                user.email = email;
                user.contact_number = c_number;
                user.isAdmin = Convert.ToBoolean(is_admin);
                user.isDelted = Convert.ToBoolean(is_deleted);
                user.isActive = Convert.ToBoolean(is_active);
            }
            catch (Exception e)
            {
                return new JsonResult(new { Status = "error", Message = "Invalid data given" });
            }
            

            db.Users.Update(user);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new JsonResult(new { Status = "error", Message = "An error has occured" });
            }

            UsersDTO edtusr = new UsersDTO
            {
                Id = user.Id,
                username = user.username,
                email = user.email,
                first_name = user.first_name,
                last_name = user.last_name,
                contact_number = user.contact_number,
                created_at = user.created_at,
                updated_at = user.updated_at,
                isAdmin = user.isAdmin,
                isActive = user.isActive,
                isDeleted = user.isDelted
            };

            return new JsonResult(new { Status = "success", Message = edtusr });
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
