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

        public DbSet<Invoices> Invoices { get; set; }

        public DbSet<InvoiceItems> InvoiceItems { get; set; }

        public DbSet<DiscountCodes> DiscountCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    name = "ETHIOPIAN LIMU",
                    desc = "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. " +
                    "Our single origin is a fully washed, high quality coffee with rich, " +
                    "round flavour and a pronounced sweetness on the palate.",
                    max_price = 28000,
                    min_price = 8000,
                    region = "Ethiopia",
                    roast = "light",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Arabic",
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                }
            );

            modelBuilder.Entity<ProductOptions>().HasData(
                new ProductOptions
                {
                    Id = 1,
                    price = 8000,
                    weight = 250,
                    quantity = 15,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    ProductID = 1,
                    isAvailable = true,
                    isDeleted = false
                },
                 new ProductOptions
                 {
                     Id = 2,
                     price = 15000,
                     weight = 500,
                     quantity = 15,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 1,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 3,
                     price = 28000,
                     weight = 1000,
                     quantity = 15,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 1,
                     isAvailable = true,
                     isDeleted = false
                 }
            );
        }

    }
}
