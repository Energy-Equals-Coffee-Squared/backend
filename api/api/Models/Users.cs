using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string username { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string email { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string first_name { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string last_name { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string password { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string contact_number { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public bool isActive { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public bool isDelted { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public bool isAdmin { get; set; }
    }
}
