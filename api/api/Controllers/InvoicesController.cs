using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly CoffeeContext db;

        public InvoicesController(CoffeeContext context)
        {
            db = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoices>>> GetInvoices()
        {
            return await db.Invoices.ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoices>> GetInvoices(int id)
        {
            var invoices = await db.Invoices.FindAsync(id);

            if (invoices == null)
            {
                return NotFound();
            }

            return invoices;
        }

        // GET: api/Invoices/averageSpentPerPerson
        [Route("averageSpentPerPerson")]
        [HttpGet]
        public async Task<ActionResult> averageSpentPerPerson()
        {
            var query = db.Invoices.Average(c => c.total_paid);

            return new JsonResult(new { Status = "success", averageSpent = (int)query });
        }

        // GET: api/Invoices/getTotalMade
        [Route("getTotalMade")]
        [HttpGet]
        public async Task<ActionResult> getTotalMade(String option)
        {
            //switch(option)
            //{
            //    case "day":
            //        var tempDay = DateTime.Now.AddDays(-1);
            //        var queryD = db.Invoices.Where(i => i.created_at >= tempDay && i.created_at <= DateTime.Now).Sum(i => i.total_paid);
            //        return new JsonResult(new { Status = "success", totalMade = queryD });
                    
            //        break;

            //    case "month":
            //        var tempMonth = DateTime.Now.AddMonths(-1);
            //        var queryMonth = db.Invoices.Where(i => i.created_at >= tempMonth && i.created_at <= DateTime.Now).Sum(i => i.total_paid);
            //        return new JsonResult(new { Status = "success", totalMade = queryMonth });


            //        break;

            //    case "week":
            //        var tempYear = DateTime.Now.AddDays(-7);
            //        var queryYear = db.Invoices.Where(i => i.created_at >= tempYear && i.created_at <= DateTime.Now).Sum(i => i.total_paid);
            //        return new JsonResult(new { Status = "success", totalMade = queryYear });

            //        break; 

            //}
            

            //return new JsonResult(new { Status = "error", Message = "Incorrect option of: " + option });


            DateTime toDate = DateTime.Now.AddDays(-1);
            //DateTime  One_Day = DateTime.Now.AddDays(-1);
            //DateTime  Two_Days = DateTime.Now.AddDays(-2);
            //DateTime  Three_Days = DateTime.Now.AddDays(-3);
            //DateTime  Four_Days = DateTime.Now.AddDays(-4);
            //DateTime  Five_Days = DateTime.Now.AddDays(-5);
            //DateTime  Six_Days = DateTime.Now.AddDays(-6);
            //DateTime  Seven_Days = DateTime.Now.AddDays(-7);

            switch (option)
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

                    var query = db.Invoices.Where(u => u.created_at >= toDate && u.created_at <= DateTime.Now).Sum(i => i.total_paid);
                    var queryY = db.Invoices.Where(u => u.created_at >= One_Day && u.created_at <= DateTime.Now).Sum(i => i.total_paid);
                    var queryTwo = db.Invoices.Where(u => u.created_at >= Two_Days && u.created_at <= One_Day).Sum(i => i.total_paid);
                    var queryThree = db.Invoices.Where(u => u.created_at >= Three_Days && u.created_at <= Two_Days).Sum(i => i.total_paid);
                    var queryFour = db.Invoices.Where(u => u.created_at >= Four_Days && u.created_at <= Three_Days).Sum(i => i.total_paid);
                    var queryFive = db.Invoices.Where(u => u.created_at >= Five_Days && u.created_at <= Four_Days).Sum(i => i.total_paid);
                    var querySix = db.Invoices.Where(u => u.created_at >= Six_Days && u.created_at <= Five_Days).Sum(i => i.total_paid);
                    var querySeven = db.Invoices.Where(u => u.created_at >= Seven_Days && u.created_at <= Six_Days).Sum(i => i.total_paid);

                    return new JsonResult(new
                    {
                        totalMade = new
                        {
                            one = queryY,
                            two = queryTwo,
                            three = queryThree,
                            four = queryFour,
                            five = queryFive,
                            six = querySix,
                            seven = querySeven
                        },
                        //option = options
                    });
                    break;

                case "week":
                    toDate = DateTime.Now.AddDays(-7);
                    DateTime WeekOne = DateTime.Now.AddDays(-7);
                    DateTime WeekTwo = DateTime.Now.AddDays(-14);
                    DateTime WeekThree = DateTime.Now.AddDays(-21);
                    DateTime WeekFour = DateTime.Now.AddDays(-28);

                    var queryWY = db.Invoices.Where(u => u.created_at >= WeekOne && u.created_at <= DateTime.Now).Sum(i => i.total_paid);
                    var queryWTwo = db.Invoices.Where(u => u.created_at >= WeekTwo && u.created_at <= WeekOne).Sum(i => i.total_paid);
                    var queryWThree = db.Invoices.Where(u => u.created_at >= WeekThree && u.created_at <= WeekTwo).Sum(i => i.total_paid);
                    var queryWFour = db.Invoices.Where(u => u.created_at >= WeekFour && u.created_at <= WeekThree).Sum(i => i.total_paid);


                    return new JsonResult(new
                    {
                        totalMade = new
                        {
                            Week_One = queryWY,
                            Week_Two = queryWTwo,
                            Week_Three = queryWThree,
                            Week_Four = queryWFour,

                        },
                        //option = options
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

                    var MO = db.Invoices.Where(u => u.created_at >= Month_one && u.created_at <= DateTime.Now).Sum(i => i.total_paid);
                    var MT = db.Invoices.Where(u => u.created_at >= Month_one && u.created_at <= DateTime.Now).Sum(i => i.total_paid);
                    var MTH = db.Invoices.Where(u => u.created_at >= Month_Two && u.created_at <= Month_one).Sum(i => i.total_paid);
                    var MF = db.Invoices.Where(u => u.created_at >= Month_Three && u.created_at <= Month_Two).Sum(i => i.total_paid);
                    var MFV = db.Invoices.Where(u => u.created_at >= Month_Four && u.created_at <= Month_Three).Sum(i => i.total_paid);
                    var MS = db.Invoices.Where(u => u.created_at >= Month_Five && u.created_at <= Month_Four).Sum(i => i.total_paid);
                    var MSE = db.Invoices.Where(u => u.created_at >= Month_Six && u.created_at <= Month_Five).Sum(i => i.total_paid);
                    var ME = db.Invoices.Where(u => u.created_at >= Month_Seven && u.created_at <= Month_Six).Sum(i => i.total_paid);
                    var MN = db.Invoices.Where(u => u.created_at >= Month_Eight && u.created_at <= Month_Seven).Sum(i => i.total_paid);
                    var MTE = db.Invoices.Where(u => u.created_at >= Month_Nine && u.created_at <= Month_Eight).Sum(i => i.total_paid);
                    var MEL = db.Invoices.Where(u => u.created_at >= Month_Eleven && u.created_at <= Month_Nine).Sum(i => i.total_paid);
                    var MTW = db.Invoices.Where(u => u.created_at >= Month_Twelve && u.created_at <= Month_Eleven).Sum(i => i.total_paid);

                    return new JsonResult(new
                    {
                        totalMade = new
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
                        //option = options
                    });

                    break;
                default:
                    return new JsonResult(new { Status = "error", Message = "Sorry boss, cant help" });
            }
        }

        // GET: api/Invoices/getOrderSummary
        [Route("getOrderSummary")]
        [HttpGet]
        public async Task<ActionResult> getOrderSummary()
        {
            try
            {
                var query = db.Invoices.Where(i => i.created_at >= DateTime.Now.AddDays(-1)).Count();

                return new JsonResult(new { Status = "success", numOrders = query });
            }
            catch (Exception e)
            {
                return new JsonResult(new { Status = "error", Message = "a problem has occured" });
            }

        }

        // POST: api/Invoices/getInvoice
        [Route("getInvoice")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<InvoicesDTO>>> getUsersInvoices(int inUserID)
        {
            var invsDTO = db.Invoices.Where(i => i.UserID.Equals(inUserID)).Select(
                i => new InvoicesDTO
                {
                    Id = i.Id,
                    UserID = i.UserID,
                    discount_code = i.discount_code,
                    discount_percentage = i.discount_percentage,
                    shipping_fee = i.shipping_fee,
                    tax = i.tax,
                    total_paid = i.total_paid,
                    total_before_discount = i.total_before_discount,
                    updated_at = i.updated_at,
                    created_at = i.created_at,
                    invoiceItems = null
                }
            ).OrderByDescending(i => i.created_at);

            var tempList = await invsDTO.ToListAsync();

            return new JsonResult(new { Status = "success", Message = tempList });
        }

        
        // POST: api/Invoices/addInvoice
        [Route("addInvoice")]
        [HttpPost]
        public async Task<ActionResult<InvoicesDTO>> addInvoice(int inUserID, string discountCode = null)
        {
            Users user = await db.Users.FindAsync(inUserID);

            if (user == null)
            {
                return new JsonResult(new { Status = "error", Message = "User Not Found" });
            }

            Invoices invoices = new Invoices
            {
                User = user,
                UserID = user.Id,
                tax = 0,
                total_paid = 0,
                total_before_discount = 0,
                shipping_fee = 0,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            if(discountCode != null)
            {
                DiscountCodes discCodes = await db.DiscountCodes.Where(ds => ds.code.Equals(discountCode.ToUpper())).FirstOrDefaultAsync();

                if (discCodes != null)
                {
                    invoices.discount_code = discCodes.code;
                    invoices.discount_percentage = discCodes.percentage;
                }
            }

            db.Invoices.Add(invoices);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new JsonResult(new { Status = "error", Message = "Error creating invoice" });
            }

            InvoicesDTO invcDTO = new InvoicesDTO
            {
                Id = invoices.Id,
                total_paid = invoices.total_paid,
                total_before_discount = invoices.total_before_discount,
                tax = invoices.tax,
                discount_code = invoices.discount_code,
                discount_percentage = invoices.discount_percentage,
                shipping_fee = invoices.shipping_fee,
                UserID = invoices.UserID,
                created_at = invoices.created_at,
                updated_at = invoices.created_at,
                invoiceItems = null
            };

            return new JsonResult(new { Status = "success", Message = invcDTO });
        }

        // POST: api/Invoices/getSpecificInvoice
        [Route("getSpecificInvoice")]
        [HttpPost]
        public async Task<ActionResult<InvoicesDTO>> getSpecificInvoice(int inUserID, int inInvoiceID)
        {
            var invsItemsDTO = await db.InvoiceItems.Where(i => i.InvoiceID.Equals(inInvoiceID)).Select(
                i => new InvoiceItemsDTO
                {
                    Id = i.Id,
                    InvoiceID = i.InvoiceID,
                    opt_price = i.opt_price,
                    opt_weight = i.opt_weight,
                    ProductOptionID = i.ProductOptionID,
                    prod_altitude_max = i.prod_altitude_max,
                    prod_altitude_min = i.prod_altitude_min,
                    prod_bean_type = i.prod_bean_type,
                    prod_desc = i.prod_desc,
                    prod_image_url = i.prod_image_url,
                    prod_name = i.prod_name,
                    prod_region = i.prod_region,
                    prod_roast = i.prod_roast,
                    quantity = i.quantity
                }
            ).ToListAsync();

            var invsDTO = await db.Invoices.Where(i => i.UserID.Equals(inUserID) && i.Id.Equals(inInvoiceID)).Select(
                i => new InvoicesDTO
                {
                    Id = i.Id,
                    UserID = i.UserID,
                    total_paid = i.total_paid,
                    total_before_discount = i.total_before_discount,
                    discount_code = i.discount_code,
                    discount_percentage = i.discount_percentage,
                    shipping_fee = i.shipping_fee,
                    tax = i.tax,
                    updated_at = i.updated_at,
                    created_at = i.created_at,
                    invoiceItems = invsItemsDTO
                }
            ).FirstOrDefaultAsync();

            return new JsonResult(new { Status = "success", Message = invsDTO });
        }

        private bool InvoicesExists(int id)
        {
            return db.Invoices.Any(e => e.Id == id);
        }
    }
}
