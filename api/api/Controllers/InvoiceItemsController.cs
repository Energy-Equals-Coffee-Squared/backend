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
    public class InvoiceItemsController : ControllerBase
    {
        private readonly CoffeeContext db;

        public InvoiceItemsController(CoffeeContext context)
        {
            db = context;
        }

        // GET: api/InvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceItems>>> GetInvoiceItems()
        {
            return await db.InvoiceItems.ToListAsync();
        }

        // GET: api/InvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceItems>> GetInvoiceItems(int id)
        {
            var invoiceItems = await db.InvoiceItems.FindAsync(id);

            if (invoiceItems == null)
            {
                return NotFound();
            }

            return invoiceItems;
        }

        // PUT: api/InvoiceItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceItems(int id, InvoiceItems invoiceItems)
        {
            if (id != invoiceItems.Id)
            {
                return BadRequest();
            }

            db.Entry(invoiceItems).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceItemsExists(id))
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

        private void updateTotalInvoice(int invID, int optPrice, int qty)
        {
            Invoices inv = db.Invoices.Find(invID);

            if(inv == null)
            {
                throw new Exception("No Invoice with the Id: "+ invID);
            }

            var total = optPrice * qty;

            inv.total_before_discount += total;

            total = Discount.CalcDiscountAmount(total, inv.discount_percentage);

            inv.total_paid += total;

            var taxRate = 15;

            inv.tax += (total / 100) * taxRate;

            inv.shipping_fee = Shipping.CalcShippingFee(total);

            db.Invoices.Update(inv);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error when trying to update product max and/or min price");
            }
        }

        // POST: api/InvoiceItems/updateShipping
        [Route("updateShipping")]
        [HttpPost]
        public async Task<ActionResult<InvoicesDTO>> updateShipping(int inInvoiceID)
        {
            Invoices inv = db.Invoices.Find(inInvoiceID);

            if (inv == null)
            {
                return new JsonResult(new { Status = "error", Message = "No Product Option With The Id: " + "No Invoice with the Id: " + inInvoiceID });
            }

            inv.total_paid += inv.shipping_fee;

            db.Invoices.Update(inv);
            try
            {
                db.SaveChanges();
                return new JsonResult(new { Status = "success", Message = "" });
            }
            catch (Exception e)
            {
                return new JsonResult(new { Status = "error", Message = "Error when trying to update product max and/or min price" });

            }
        }

        // POST: api/InvoiceItems/addItem
        [Route("addItem")]
        [HttpPost]
        public async Task<ActionResult<InvoicesDTO>> addItem(int inInvoiceID, int inProductOptionID, int inQuantity)
        {
            Invoices invoice = await db.Invoices.FindAsync(inInvoiceID);

            if (invoice == null)
            {
                return new JsonResult(new { Status = "error", Message = "No Invoices With The Id: "+inInvoiceID });
            }

            ProductOptions prodOpt = await db.ProductOptions.FindAsync(inProductOptionID);

            if (prodOpt == null)
            {
                return new JsonResult(new { Status = "error", Message = "No Product Option With The Id: " + inProductOptionID });
            }

            Products prod = await db.Products.FindAsync(prodOpt.ProductID);

            if (prod == null)
            {
                return new JsonResult(new { Status = "error", Message = "No Product With The Id: " + prodOpt.ProductID });
            }

            prodOpt.Product = prod;

            if (inQuantity < 1)
            {
                return new JsonResult(new { Status = "error", Message = "Quantity Can't be less than 1"});
            }


            InvoiceItems invoiceItems = new InvoiceItems
            {
                InvoiceID = invoice.Id,
                ProductOptionID = prodOpt.Id,
                prod_name = prodOpt.Product.name,
                prod_desc = prodOpt.Product.desc,
                prod_region = prodOpt.Product.region,
                prod_roast = prodOpt.Product.roast,
                prod_altitude_max = prodOpt.Product.altitude_max,
                prod_altitude_min = prodOpt.Product.altitude_min,
                prod_bean_type = prodOpt.Product.bean_type,
                prod_image_url = prodOpt.Product.image_url,
                opt_tax_amount = prodOpt.tax_amount,
                opt_price = prodOpt.price,
                opt_weight = prodOpt.weight,
                quantity = inQuantity
            };

            db.InvoiceItems.Add(invoiceItems);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new JsonResult(new { Status = "error", Message = "Error adding item to invoice" });
            }

            try
            {
                updateTotalInvoice(invoice.Id, invoiceItems.opt_price, invoiceItems.quantity);
            }
            catch(Exception e)
            {
                return new JsonResult(new { Status = "error", Message = e });
            }

            InvoicesDTO invcDTO = new InvoicesDTO
            {
                Id = invoice.Id,
                total_paid = invoice.total_paid,
                total_before_discount = invoice.total_before_discount,
                UserID = invoice.UserID,
                discount_code = invoice.discount_code,
                discount_percentage = invoice.discount_percentage,
                shipping_fee = invoice.shipping_fee,
                tax = invoice.tax,
                created_at = invoice.created_at,
                updated_at = invoice.created_at
            };

            InvoiceItemsDTO invoiceItemsDTO = new InvoiceItemsDTO
            {
                Id = invoiceItems.Id,
                InvoiceID = invoice.Id,
                ProductOptionID = prodOpt.Id,
                prod_name = prodOpt.Product.name,
                prod_desc = prodOpt.Product.desc,
                prod_region = prodOpt.Product.region,
                prod_roast = prodOpt.Product.roast,
                prod_altitude_max = prodOpt.Product.altitude_max,
                prod_altitude_min = prodOpt.Product.altitude_min,
                prod_bean_type = prodOpt.Product.bean_type,
                prod_image_url = prodOpt.Product.image_url,
                opt_price = prodOpt.price,
                opt_weight = prodOpt.weight,                
                quantity = inQuantity
            };

            if(invcDTO.invoiceItems == null)
            {
                List<InvoiceItemsDTO> tempList = new List<InvoiceItemsDTO>();
                tempList.Add(invoiceItemsDTO);
                invcDTO.invoiceItems = tempList;
            }
            else
            {
                invcDTO.invoiceItems.Add(invoiceItemsDTO);
            }

            return new JsonResult(new { Status = "success", Message = invcDTO });
        }

        // DELETE: api/InvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceItems>> DeleteInvoiceItems(int id)
        {
            var invoiceItems = await db.InvoiceItems.FindAsync(id);
            if (invoiceItems == null)
            {
                return NotFound();
            }

            db.InvoiceItems.Remove(invoiceItems);
            await db.SaveChangesAsync();

            return invoiceItems;
        }

        private bool InvoiceItemsExists(int id)
        {
            return db.InvoiceItems.Any(e => e.Id == id);
        }
    }
}
