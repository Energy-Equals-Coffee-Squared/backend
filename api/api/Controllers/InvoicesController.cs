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

        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoices(int id, Invoices invoices)
        {
            if (id != invoices.Id)
            {
                return BadRequest();
            }

            db.Entry(invoices).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        // POST: api/Invoices/addInvoice
        [Route("addInvoice")]
        [HttpPost]
        public async Task<ActionResult<InvoicesDTO>> addInvoice(int inUserID)
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
                total = 0,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

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
                total = invoices.total,
                UserID = invoices.UserID,
                created_at = invoices.created_at,
                updated_at = invoices.created_at,
                invoiceItems = null
            };

            return new JsonResult(new { Status = "success", Message = invcDTO });
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoices>> DeleteInvoices(int id)
        {
            var invoices = await db.Invoices.FindAsync(id);
            if (invoices == null)
            {
                return NotFound();
            }

            db.Invoices.Remove(invoices);
            await db.SaveChangesAsync();

            return invoices;
        }

        private bool InvoicesExists(int id)
        {
            return db.Invoices.Any(e => e.Id == id);
        }
    }
}
