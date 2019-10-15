using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class InvoiceItemsDTO
    {
        public int Id { get; set; }
        public int InvoiceID { get; set; }
        public int ProductOptionID { get; set; }
        public string prod_name { get; set; }
        public string prod_desc { get; set; }
        public string prod_region { get; set; }
        public string prod_roast { get; set; }
        public int prod_altitude_max { get; set; }
        public int prod_altitude_min { get; set; }
        public string prod_bean_type { get; set; }
        public string prod_image_url { get; set; }
        public int opt_price { get; set; }
        public int opt_weight { get; set; }
        public int quantity { get; set; }
    }
}
