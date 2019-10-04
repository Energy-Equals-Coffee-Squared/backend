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
    public class ProductOptionsController : ControllerBase
    {
        private readonly CoffeeContext db;

        public ProductOptionsController(CoffeeContext context)
        {
            db = context;
        }

        // GET: api/ProductOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOptions>>> GetProductOptions()
        {
            return await db.ProductOptions.ToListAsync();
        }

        // GET: api/ProductOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOptions>> GetProductOptions(int id)
        {
            var productOptions = await db.ProductOptions.FindAsync(id);

            if (productOptions == null)
            {
                return NotFound();
            }

            return productOptions;
        }

        // PUT: api/ProductOptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOptions(int id, ProductOptions productOptions)
        {
            if (id != productOptions.Id)
            {
                return BadRequest();
            }

            db.Entry(productOptions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOptionsExists(id))
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

        // POST: api/ProductOptions
        [HttpPost]
        public async Task<ActionResult<ProductOptions>> PostProductOptions(
            int inPrice, int inWeight,
            int inQuantity, int inProduct_id
        )
        {
            ProductOptions productOptions = new ProductOptions
            {
                price = inPrice,
                weight = inWeight,
                quantity = inQuantity,
                product_id = inProduct_id
            };
            db.ProductOptions.Add(productOptions);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetProductOptions", new { id = productOptions.Id }, productOptions);
        }

        // DELETE: api/ProductOptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductOptions>> DeleteProductOptions(int id)
        {
            var productOptions = await db.ProductOptions.FindAsync(id);
            if (productOptions == null)
            {
                return NotFound();
            }

            db.ProductOptions.Remove(productOptions);
            await db.SaveChangesAsync();

            return productOptions;
        }

        private bool ProductOptionsExists(int id)
        {
            return db.ProductOptions.Any(e => e.Id == id);
        }
    }
}
