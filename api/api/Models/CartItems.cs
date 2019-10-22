using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CartItems
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int CartID { get; set; }
        public Cart Cart { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int ProductOptionID { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string prod_name { get; set; }
        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string prod_desc { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string prod_region { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string prod_roast { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int prod_altitude_max { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int prod_altitude_min { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string prod_bean_type { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string prod_image_url { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int opt_tax_amount { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int opt_price { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int opt_weight { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int quantity { get; set; }
    }
}
