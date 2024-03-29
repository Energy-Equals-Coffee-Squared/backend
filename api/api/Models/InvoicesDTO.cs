﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class InvoicesDTO
    {
        public int Id { get; set; }
        public int tax { get; set; }
        public string discount_code { get; set; }
        public int discount_percentage { get; set; }
        public bool isFreeShipping { get; set; }
        public int total { get; set; }
        public int UserID { get; set; }
        public List<InvoiceItemsDTO> invoiceItems { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
