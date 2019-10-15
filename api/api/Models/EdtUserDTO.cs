using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EdtUserDTO
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string contact_number { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; } 
        public bool isAdmin { get; set; }
    }
}
