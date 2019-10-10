using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProductOptions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int price { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int weight { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int quantity { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get; set; }
        [Required]
        [ForeignKey("Prodcut")]
        [Column(TypeName = "int")]
        public int ProductID { get; set; }

        public Products Product { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public bool isAvailable { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public bool isDeleted { get; set; }
    }
}
