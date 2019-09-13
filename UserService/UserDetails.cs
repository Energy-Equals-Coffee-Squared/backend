﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService
{

    public class UserDetails
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string contact_number { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool isActive { get; set; }
        public bool isAdmin { get; set; }
        public bool isDeleted { get; set; }
    }
}