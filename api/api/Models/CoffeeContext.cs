using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<ProductOptions> ProductOptions { get; set; }

    }
}
