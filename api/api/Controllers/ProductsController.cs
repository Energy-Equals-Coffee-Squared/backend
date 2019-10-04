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
    public class ProductsController : ControllerBase
    {
        private readonly CoffeeContext db;

        public ProductsController(CoffeeContext context)
        {
            db = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetProducts()
        {
            var prods = db.Products.Select(
                p => new ProductsDTO{
                    Id = p.Id,
                    name = p.name,
                    desc = p.desc,
                    region = p.region,
                    roast = p.roast,
                    altitude_max = p.altitude_max,
                    altitude_min = p.altitude_min,
                    bean_type = p.bean_type,
                    created_at = p.created_at,
                    updated_at = p.updated_at,
                    image_url = p.image_url
                }
            ).ToListAsync();

            return await prods;
        }

        // GET: api/Products/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetSingleProduct(int id)
        {
            if (!ProductsExists(id))
            {
                return NotFound();
            }

            var listProductOptions = await db.ProductOptions.Where(
                    po => po.product_id.Equals(id)
                ).Select(
                    po => new ProductOptionsDTO()
                    {
                        Id = po.Id,
                        price = po.price,
                        quantity = po.quantity,
                        weight = po.weight,
                        product_id = po.product_id,
                        isDeleted = po.isDeleted,
                        isAvailable = po.isAvailable,
                        created_at = po.created_at,
                        updated_at = po.updated_at
                    }
                ).ToListAsync();

            var products = await db.Products.Where(
                p => p.Id.Equals(id) 
                && p.isDeleted.Equals(false)
                ).Select(
                    p => new ProductsDTO()
                    {
                        Id = p.Id,
                        name = p.name,
                        desc = p.desc,
                        region = p.region,
                        roast = p.roast,                        
                        altitude_max = p.altitude_max,
                        altitude_min = p.altitude_min,
                        bean_type = p.bean_type,
                        created_at = p.created_at,
                        updated_at = p.updated_at,
                        image_url = p.image_url,
                        productOptions = listProductOptions
                    }
                ).ToListAsync();

            
            return products;
        }


        // POST: api/Products
        [Route("addProduct")]
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(
            string inName, string inDesc, 
            string inRegion, string inRoast,
            int inAltitude_max, int inAltitude_min,
            string inBean_type, string inImage_url
        )
        {
            Products products = new Products
            {
                name = inName,
                desc = inDesc,
                region = inRegion,
                roast = inRoast,
                altitude_max = inAltitude_max,
                altitude_min = inAltitude_min,
                bean_type = inBean_type,
                image_url = inImage_url,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                isDeleted = false
            };

            db.Products.Add(products);
            try
            {
                await db.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return ValidationProblem();
            }
            

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }

        private bool ProductsExists(int id)
        {
            return db.Products.Any(e => e.Id == id);
        }
    }
}
