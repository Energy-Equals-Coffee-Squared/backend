using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService
{
    public class ProductClass
    {
      public string name;
        public string desc;
        public string region;
        public string roast;
        public int altitude_max;
        public int altitude_min;
        public DateTime created_at;
        public DateTime updated_at;
        public bool isDeleted;
        public string bean_type;
    }
}