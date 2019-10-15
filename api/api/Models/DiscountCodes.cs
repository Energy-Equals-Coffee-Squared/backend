using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class DiscountCodes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string code { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int percentage { get; set; }
    }
}
