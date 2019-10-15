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
    public class DiscountCodesController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public DiscountCodesController(CoffeeContext context)
        {
            _context = context;
        }

        // GET: api/DiscountCodes/5
        [HttpGet("{code}")]
        public async Task<ActionResult<DiscountCodeDTO>> GetDiscountCodes(string code)
        {
            var discountCodes = await _context.DiscountCodes.Where(d => d.code.Equals(code.ToUpper())).Select(
                d => new DiscountCodeDTO
                {
                    Id = d.Id,
                    code = d.code,
                    percentage = d.percentage                    
                } 
                ).FirstOrDefaultAsync();

            if (discountCodes == null)
            {
                return new JsonResult(new { Status = "error", Message = "Discount Code is not valid"});
            }

            return new JsonResult(new { Status = "success", Message = discountCodes });
        }

        private bool DiscountCodesExists(int id)
        {
            return _context.DiscountCodes.Any(e => e.Id == id);
        }
    }
}
