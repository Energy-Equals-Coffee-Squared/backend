using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProductOptionsDTO
    {
        public int Id { get; set; }
        public int price { get; set; }
        public int tax_amount { get; set; }
        public int weight { get; set; }
        public int quantity { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int ProductID { get; set; }
        public bool isAvailable { get; set; }
        public bool isDeleted { get; set; }
    }
}
