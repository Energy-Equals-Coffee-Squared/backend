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

        private void updateMaxMinPrice(int prodID, int newPrice)
        {
            var prod = db.Products.Find(prodID);
            if (prod == null)
            {
                throw new Exception("No Product Found with the ID provided");
            }
            else
            {
                int numChanges = 0;
                // if both the max and min price are 0 set them both to the new price
                if (prod.max_price == 0 && prod.max_price == 0)
                {
                    prod.max_price = newPrice;
                    prod.min_price = newPrice;
                    numChanges++;
                }
                else if (prod.max_price < newPrice)
                {
                    prod.max_price = newPrice;
                    numChanges++;
                }
                else if (prod.min_price > newPrice)
                {
                    prod.min_price = newPrice;
                    numChanges++;
                }

                // if there are no changes made
                if (numChanges > 0)
                {
                    db.Products.Update(prod);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error when trying to update product max and/or min price");
                    }
                }
            }
        }

        // POST: api/ProductOptions
        [HttpPost]
        public async Task<ActionResult<ProductOptions>> PostProductOptions(
            int inPrice, int inWeight,
            int inQuantity, int inProductID
        )
        {
            ProductOptions productOptions = new ProductOptions
            {
                price = inPrice,
                weight = inWeight,
                quantity = inQuantity,
                ProductID = inProductID
            };
            try
            {
                db.ProductOptions.Add(productOptions);
                await db.SaveChangesAsync();

                updateMaxMinPrice(productOptions.ProductID, productOptions.price);

                return CreatedAtAction("GetProductOptions", new { id = productOptions.Id }, productOptions);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Status = "Error", ex.Message });
            };
        }

        private bool ProductOptionsExists(int id)
        {
            return db.ProductOptions.Any(e => e.Id == id);
        }
    }
}
