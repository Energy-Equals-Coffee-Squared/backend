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
        public async Task<ActionResult> getTotalMade()
        {
            var query = db.Invoices.Sum(i => i.total_paid);

            return new JsonResult(new { Status = "success", totalMade = query });
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
