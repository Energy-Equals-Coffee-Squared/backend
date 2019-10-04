using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string region { get; set; }
        public string roast { get; set; }
        public int altitude_max { get; set; }
        public int altitude_min { get; set; }
        public string bean_type { get; set; }
        public string image_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<ProductOptionsDTO> productOptions { get; set; }
    }
}
