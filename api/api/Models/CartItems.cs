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
        public ProductOptions ProductOption { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int quantity { get; set; }
    }
}
