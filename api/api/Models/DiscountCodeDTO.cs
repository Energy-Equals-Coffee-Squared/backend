using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class DiscountCodeDTO
    {
        public int Id { get; set; }
        public string code { get; set; }
        public int percentage { get; set; }
    }
}
