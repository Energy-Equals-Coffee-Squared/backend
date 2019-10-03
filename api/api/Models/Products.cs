﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string name { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string desc { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string region { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string roast { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int altitude_max { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int altitude_min { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public bool bean_type { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public bool image_url { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime created_at { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]
        public bool isDelted { get; set; }
        
    }
}