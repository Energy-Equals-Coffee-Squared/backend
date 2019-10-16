using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Invoices
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int tax { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string discount_code { get; set; }
        [Column(TypeName = "int")]
        public int discount_percentage { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public bool isExpressShipping { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int total { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int UserID { get; set; }
        public Users User { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get; set; }

    }
}
