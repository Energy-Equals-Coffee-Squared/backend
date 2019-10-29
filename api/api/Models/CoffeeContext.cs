using api.Helpers;
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

        public DbSet<Cart> Cart { get; set; }

        public DbSet<CartItems> CartItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscountCodes>().HasData(
                new DiscountCodes
                {
                    Id = 1, 
                    code = "15OFF",
                    percentage = 15
                }
            );
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    username = "Fluffy",
                    email = "fluffy@gmail.com",
                    first_name = "Andrew",
                    last_name = "Walls",
                    password = "00fcdde26dd77af7858a52e3913e6f3330a32b3121a61bce915cc6145fc44453",
                    contact_number = "0728291496	",
                    created_at = Convert.ToDateTime("09 / 22 / 2019"),
                    updated_at = Convert.ToDateTime("09 / 22 / 2019"),
                    isActive = true,
                    isAdmin = true
                },
                new Users
                {
                    Id = 2,
                    username = "Anton",
                    email = "anton@gmail.com",
                    first_name = "Anton",
                    last_name = "Röscher",
                    password = "b786fbda93a09a3d4df30b3f021679abb16c6e2cd1384586cbb1d76049a474bc",
                    contact_number = "0821111111",
                    created_at = Convert.ToDateTime("10 / 22 / 2019"),
                    updated_at = Convert.ToDateTime("10 / 22 / 2019"),
                    isActive = true,
                    isAdmin = true
                },
                new Users
                {
                    Id = 3,
                    username = "Minimac",
                    email = "thom@gmail.com",
                    first_name = "Thomas",
                    last_name = "McAlpine",
                    password = "9e8e9dcc20b56023a0ce12400ef1dce7e151f48caec39fd276d908e3593fb280",
                    contact_number = "0821113333",
                    created_at = Convert.ToDateTime("10 / 01 / 2019"),
                    updated_at = Convert.ToDateTime("10 / 01 / 2019"),
                    isActive = true,
                    isAdmin = true
                },
                 new Users
                 {
                     Id = 4,
                     username = "Jimmy",
                     email = "jimbo@gmail.com",
                     first_name = "Jimbo",
                     last_name = "Botswane",
                     password = "f8fd9810608bd6eee15cb8de8290c161c1b6a503e03cd5607ecfc56f2213ab6a",
                     contact_number = "0724444444",
                     created_at = Convert.ToDateTime("09 / 11 / 2019"),
                     updated_at = Convert.ToDateTime("10 / 01 / 2019"),
                     isActive = true,
                     isAdmin = false
                 },
                  new Users
                  {
                      Id = 5,
                      username = "Noizing",
                      email = "Noizing@yahoo.com",
                      first_name = "Nikita",
                      last_name = "van der Merwe",
                      password = "cc9928dbbd1ba4803064cf22530c30409de3c2b8c222eb7956ad50e5e4ec6872",
                      contact_number = "0726664432",
                      created_at = Convert.ToDateTime("10 / 17 / 2019"),
                      updated_at = Convert.ToDateTime("10 / 19 / 2019"),
                      isActive = true,
                      isAdmin = false
                  },
                   new Users
                   {
                       Id = 6,
                       username = "pillies",
                       email = "picka@uj.ac.za",
                       first_name = "Prince",
                       last_name = "Thabotsa",
                       password = "e22854c624ce2c6a18064a0247411174b5991ceb6e035472e872927370a21a99",
                       contact_number = "0821113333",
                       created_at = Convert.ToDateTime("10 / 22 / 2019"),
                       updated_at = Convert.ToDateTime("10 / 22 / 2019"),
                       isActive = true,
                       isAdmin = false
                   }
                );
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
                    image_url = "1.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 2,
                    name = "Truth. - Ethiopia Guji",
                    desc = "Guji is one of those regions of Ethiopia that have garnered much more " +
                    "attention in recent years, competing with the classically popular areas like Yirgacheffe " +
                    "& Limu.",
                    max_price = 31000,
                    min_price = 9000,
                    region = "Ethiopia",
                    roast = "Medium",
                    altitude_max = 2500,
                    altitude_min = 2000,
                    bean_type = "Hierloom",
                    image_url = "2.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 3,
                    name = "Truth. - Burundi",
                    desc = "Truth seems to have had a bit of a love affair with Burundian coffee in the last few years" +
                    ", one from which we have all benefited. They've had a streak of delicious examples of the up and " +
                    "coming coffee producing country's very best exports that we have thoroughly enjoyed.",
                    max_price = 32000,
                    min_price = 10000,
                    region = "Burundi",
                    roast = "light",
                    altitude_max = 1800,
                    altitude_min = 1600,
                    bean_type = "Arabic",
                    image_url = "3.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 4,
                    name = "Bean There - Blend 44",
                    desc = "Bean There's Blend 44 combines their very popular Ethiopia Sidamo, and one of our " +
                    "favourites, their Burundi Musema & Nyarurama. The marriage of these two wonderful coffees yields " +
                    "everything you might want in a bold yet balanced coffee, suitable for manual brewing or espresso.",
                    max_price = 25000,
                    min_price = 6000,
                    region = "Ethiopia",
                    roast = "Light",
                    altitude_max = 10000,
                    altitude_min = 9500,
                    bean_type = "Blend",
                    image_url = "4.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 5,
                    name = "Legado - Bolivia Villa Rosario Organic",
                    desc = "Villa Rosario is a colony in the Caranavi area of Yungus. The colony is located between 1550 and 1650 masl and is surrounded by " +
                    "jungle and small coffee farms.",
                    max_price = 16000,
                    min_price = 8000,
                    region = "Bolivia",
                    roast = "Dark",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Arabic",
                    image_url = "5.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 6,
                    name = "Origin Coffee Roasting - Guatemala Santa Sofia",
                    desc = "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a " +
                    "chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.",
                    max_price = 35000,
                    min_price = 15000,
                    region = "Guatamala",
                    roast = "light",
                    altitude_max = 1700,
                    altitude_min = 1675,
                    bean_type = "Primarily Caturra & Catuai",
                    image_url = "6.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 7,
                    name = "Portland Project - Costa Rica Trojas",
                    desc = "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee " +
                    "growing world. Its acidity is very discrete and body is full and satisfying.",
                    max_price = 29000,
                    min_price = 10000,
                    region = "Costa Rica",
                    roast = "Dark",
                    altitude_max = 1600,
                    altitude_min = 1220,
                    bean_type = "Heirloom",
                    image_url = "7.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 8,
                    name = "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot",
                    desc = "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, " +
                    "and this may be in part due to the experimental processing method employed." ,
                    max_price = 17000,
                    min_price = 10000,
                    region = "Nicaragua",
                    roast = "Medium",
                    altitude_max = 1200,
                    altitude_min = 1100,
                    bean_type = "Finca Idealista",
                    image_url = "8.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 9,
                    name = "Rosetta Roastery - Honduras San Franscisco Natural",
                    desc = "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, " +
                    "at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.",
                    max_price = 32000,
                    min_price = 18000,
                    region = "Honduras",
                    roast = "Dark",
                    altitude_max = 1600,
                    altitude_min = 1420,
                    bean_type = "Catui",
                    image_url = "9.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 10,
                    name = "BURUNDI KIBIRA",
                    desc = "Bourbon type varietal." +
                    "Cup profiles can be dynamic and bright, with red fruits, berry or citrus." +
                    "Medium body and rounded mouth feel with a lingering finish." +
                    "It’s no secret that Burundi has the potential to produce great coffee.",
                    max_price = 36000,
                    min_price = 10000,
                    region = "India",
                    roast = "light",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "BVurundi",
                    image_url = "10.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 11,
                    name = "Truth. - India Single Origin",
                    desc = "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no " +
                    "longer bears the name, the coffees from that area are still referred to as Indian Mysore.",
                    max_price = 28000,
                    min_price = 8000,
                    region = "India",
                    roast = "Medium",
                    altitude_max = 1350,
                    altitude_min = 1000,
                    bean_type = "Cauvery",
                    image_url = "11.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 12,
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
                    image_url = "12.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 13,
                    name = "Origin Coffee Roasting - Rwanda Musasa Ruli",
                    desc = "Rwanda Musasa is a returning favourite from Origin Coffee Roasting. Highly celebrated, the Musasa Dukunde Kawa Cooperative is known " +
                    "all over the world for its top quality Red Bourbon beans.",
                    max_price = 28000,
                    min_price = 8000,
                    region = "Ruli",
                    roast = "light",
                    altitude_max = 2000,
                    altitude_min = 1700,
                    bean_type = "Red Bourbon",
                    image_url = "13.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 14,
                    name = "Fruit Salad Cape Coffee Blend",
                    desc = "This blend was concocted early one morning when there just wasn't enough of one of the components, and a certain CCTeam member " +
                    "thought, 'what the heck ?'  And so, a blend was born, and it tasted like fruit salad in a cup. It kind of makes sense in the end if you " +
                    "think about it.",
                    max_price = 26000,
                    min_price = 12500,
                    region = "South Afica",
                    roast = "Medium",
                    altitude_max = 1200,
                    altitude_min = 1100,
                    bean_type = "Blend",
                    image_url = "14.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 15,
                    name = "Rosetta Roastery - Honduras San Franscisco Natural",
                    desc = "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least" +
                    " here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.",
                    max_price = 60000,
                    min_price = 16000,
                    region = "Marcala",
                    roast = "Dark",
                    altitude_max = 1600,
                    altitude_min = 1550,
                    bean_type = "Catuai",
                    image_url = "15.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 16,
                    name = "hazz blend - coffee for heroes",
                    desc = "häzz coffee is a rich and subtle, truly modern blend of South American and African origin, suitable for any palate.  It offers an " +
                    "exceptionally wide range of aromas, accompanied by a bold but round and smooth body." +
                    "In 2012, it won a Gold Medal at the annual International Coffee Tasting in Italy.",
                    max_price = 30000,
                    min_price = 12500,
                    region = "South America and Africa",
                    roast = "light",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Blend",
                    image_url = "16.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 17,
                    name = "Tribe Coffee - Espresso Blend",
                    desc = "Tribe Coffee's Espresso Blend has quickly earned them a reputation in and around Cape Town. Full-bodied and well-developed, it " +
                    "makes great milk & espresso-based drinks which is why you'll find it in many restaurants and cafés in the Mother City!",
                    max_price = 45500,
                    min_price = 22000,
                    region = "SouthAfrica",
                    roast = "Dark",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Blend",
                    image_url = "17.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 18,
                    name = "ETHIOPIAN HARRAR",
                    desc = "Heavy-bodied, spicy and fragrant, Ethiopian Harrar coffee is a wild and exotic dry processed (natural) Arabica coffee that is " +
                    "grown on small farms in the Oromia region (formerly Harrar) in southern Ethiopia at elevations between 1,400 meters and 2,000 meters.",
                    max_price = 21200,
                    min_price = 15100,
                    region = "Ethiopia",
                    roast = "Medium",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Harrar",
                    image_url = "18.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 19,
                    name = "BRU Etheopia",
                    desc = "A full bodied, sweet with fruity after taste. We roast this coffee medium-dark to maintain the complex flavours, a coffee" +
                    " that will place a smile on any connoisseurs face.",
                    max_price = 50000,
                    min_price = 32000,
                    region = "Ethiopia",
                    roast = "Medium",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Arabica",
                    image_url = "19.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 20,
                    name = "Coffee Lab Alpha",
                    desc = "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha " +
                    "coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity",
                    max_price = 30000,
                    min_price = 12000,
                    region = "South Africa",
                    roast = "Dark",
                    altitude_max = 10000,
                    altitude_min = 9000,
                    bean_type = "Catuai",
                    image_url = "20.png",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 21,
                    name = "Titanium Coffee Turkish",
                    desc = "Turkish Coffee ground to the finest Powder with a touch of elachi spice for that exotic flavour.",
                    max_price = 28000,
                    min_price = 8000,
                    region = "Turkish",
                    roast = "Dark",
                    altitude_max = 5000,
                    altitude_min = 3500,
                    bean_type = "Arabic",
                    image_url = "21.png",
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
                    tax_amount = Tax.CalcTax(8000),
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
                     tax_amount = Tax.CalcTax(15000),
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
                     tax_amount = Tax.CalcTax(28000),
                     weight = 1000,
                     quantity = 15,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 1,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 4,
                     price = 9000,
                     tax_amount = Tax.CalcTax(9000),
                     weight = 250,
                     quantity = 10,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 2,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 5,
                     price = 15000,
                     tax_amount = Tax.CalcTax(15000),
                     weight = 500,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 2,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 6,
                     price = 31000,
                     tax_amount = Tax.CalcTax(31000),
                     weight = 1000,
                     quantity = 12,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 2,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 7,
                     price = 10000,
                     tax_amount = Tax.CalcTax(10000),
                     weight = 250,
                     quantity = 13,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 3,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 8,
                     price = 22000,
                     tax_amount = Tax.CalcTax(22000),
                     weight = 500,
                     quantity = 25,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 3,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 9,
                     price = 32000,
                     tax_amount = Tax.CalcTax(32000),
                     weight = 1000,
                     quantity = 5,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 3,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 10,
                     price = 6000,
                     tax_amount = Tax.CalcTax(6000),
                     weight = 250,
                     quantity = 13,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 4,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 11,
                     price = 14000,
                     tax_amount = Tax.CalcTax(14000),
                     weight = 500,
                     quantity = 35,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 4,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 12,
                     price = 25000,
                     tax_amount = Tax.CalcTax(25000),
                     weight = 1000,
                     quantity = 19,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 4,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 13,
                     price = 8000,
                     tax_amount = Tax.CalcTax(8000),
                     weight = 250,
                     quantity = 16,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 5,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 14,
                     price = 12000,
                     tax_amount = Tax.CalcTax(12000),
                     weight = 500,
                     quantity = 17,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 5,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 15,
                     price = 16000,
                     tax_amount = Tax.CalcTax(16000),
                     weight = 1000,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 5,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 16,
                     price = 15000,
                     tax_amount = Tax.CalcTax(15000),
                     weight = 250,
                     quantity = 33,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 6,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 17,
                     price = 20000,
                     tax_amount = Tax.CalcTax(20000),
                     weight = 500,
                     quantity = 25,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 6,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 18,
                     price = 35000,
                     tax_amount = Tax.CalcTax(35000),
                     weight = 1000,
                     quantity = 19,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 6,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 19,
                     price = 10000,
                     tax_amount = Tax.CalcTax(10000),
                     weight = 250,
                     quantity = 16,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 7,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 20,
                     price = 19000,
                     tax_amount = Tax.CalcTax(19000),
                     weight = 500,
                     quantity = 15,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 7,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 21,
                     price = 29000,
                     tax_amount = Tax.CalcTax(29000),
                     weight = 1000,
                     quantity = 17,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 7,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 22,
                     price = 10000,
                     tax_amount = Tax.CalcTax(10000),
                     weight = 250,
                     quantity = 17,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 8,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 23,
                     price = 13500,
                     tax_amount = Tax.CalcTax(13500),
                     weight = 500,
                     quantity = 13,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 8,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 24,
                     price = 17000,
                     tax_amount = Tax.CalcTax(17000),
                     weight = 1000,
                     quantity = 25,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 8,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 25,
                     price = 18000,
                     tax_amount = Tax.CalcTax(18000),
                     weight = 250,
                     quantity = 35,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 9,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 26,
                     price = 26000,
                     tax_amount = Tax.CalcTax(26000),
                     weight = 500,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 9,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 27,
                     price = 32000,
                     tax_amount = Tax.CalcTax(32000),
                     weight = 1000,
                     quantity = 9,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 9,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 28,
                     price = 10000,
                     tax_amount = Tax.CalcTax(10000),
                     weight = 250,
                     quantity = 15,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 10,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 29,
                     price = 19000,
                     tax_amount = Tax.CalcTax(19000),
                     weight = 500,
                     quantity = 21,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 10,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 30,
                     price = 36000,
                     tax_amount = Tax.CalcTax(36000),
                     weight = 1000,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 10,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 31,
                     price = 8000,
                     tax_amount = Tax.CalcTax(8000),
                     weight = 250,
                     quantity = 7,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 11,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 32,
                     price = 15000,
                     tax_amount = Tax.CalcTax(15000),
                     weight = 500,
                     quantity = 13,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 11,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 33,
                     price = 28000,
                     tax_amount = Tax.CalcTax(28000),
                     weight = 1000,
                     quantity = 33,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 11,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 34,
                     price = 8000,
                     tax_amount = Tax.CalcTax(8000),
                     weight = 250,
                     quantity = 6,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 12,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 35,
                     price = 15000,
                     tax_amount = Tax.CalcTax(15000),
                     weight = 500,
                     quantity = 7,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 12,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 36,
                     price = 28000,
                     tax_amount = Tax.CalcTax(28000),
                     weight = 1000,
                     quantity = 8,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 12,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 37,
                     price = 8000,
                     tax_amount = Tax.CalcTax(8000),
                     weight = 250,
                     quantity = 22,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 13,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 38,
                     price = 15000,
                     tax_amount = Tax.CalcTax(15000),
                     weight = 500,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 13,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 39,
                     price = 28000,
                     tax_amount = Tax.CalcTax(28000),
                     weight = 1000,
                     quantity = 44,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 13,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 40,
                     price = 12500,
                     tax_amount = Tax.CalcTax(12500),
                     weight = 250,
                     quantity = 15,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 14,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 41,
                     price = 18000,
                     tax_amount = Tax.CalcTax(18000),
                     weight = 500,
                     quantity = 16,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 14,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 42,
                     price = 26000,
                     tax_amount = Tax.CalcTax(26000),
                     weight = 1000,
                     quantity = 17,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 14,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 43,
                     price = 16000,
                     tax_amount = Tax.CalcTax(16000),
                     weight = 250,
                     quantity = 12,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 15,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 44,
                     price = 32000,
                     tax_amount = Tax.CalcTax(32000),
                     weight = 500,
                     quantity = 22,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 15,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 45,
                     price = 60000,
                     tax_amount = Tax.CalcTax(60000),
                     weight = 1000,
                     quantity = 26,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 15,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 46,
                     price = 12500,
                     tax_amount = Tax.CalcTax(12500),
                     weight = 250,
                     quantity = 4,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 16,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 47,
                     price = 17000,
                     tax_amount = Tax.CalcTax(17000),
                     weight = 500,
                     quantity = 22,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 16,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 48,
                     price = 30000,
                     tax_amount = Tax.CalcTax(30000),
                     weight = 1000,
                     quantity = 9,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 16,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 49,
                     price = 22000,
                     tax_amount = Tax.CalcTax(22000),
                     weight = 250,
                     quantity = 21,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 17,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 50,
                     price = 31000,
                     tax_amount = Tax.CalcTax(31000),
                     weight = 500,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 17,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 51,
                     price = 45500,
                     tax_amount = Tax.CalcTax(45500),
                     weight = 1000,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 17,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 52,
                     price = 15100,
                     tax_amount = Tax.CalcTax(15100),
                     weight = 250,
                     quantity = 22,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 18,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 53,
                     price = 18000,
                     tax_amount = Tax.CalcTax(18000),
                     weight = 500,
                     quantity = 12,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 18,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 54,
                     price = 21200,
                     tax_amount = Tax.CalcTax(21200),
                     weight = 1000,
                     quantity = 32,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 18,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 55,
                     price = 32000,
                     tax_amount = Tax.CalcTax(32000),
                     weight = 250,
                     quantity = 21,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 19,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 56,
                     price = 40000,
                     tax_amount = Tax.CalcTax(40000),
                     weight = 500,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 19,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 57,
                     price = 50000,
                     tax_amount = Tax.CalcTax(50000),
                     weight = 1000,
                     quantity = 15,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 19,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 58,
                     price = 12000,
                     tax_amount = Tax.CalcTax(12000),
                     weight = 250,
                     quantity = 44,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 20,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 59,
                     price = 20000,
                     tax_amount = Tax.CalcTax(20000),
                     weight = 500,
                     quantity = 15,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 20,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 60,
                     price = 30000,
                     tax_amount = Tax.CalcTax(30000),
                     weight = 1000,
                     quantity = 21,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 20,
                     isAvailable = true,
                     isDeleted = false
                 },

                 new ProductOptions
                 {
                     Id = 61,
                     price = 8000,
                     tax_amount = Tax.CalcTax(8000),
                     weight = 250,
                     quantity = 11,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 21,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 62,
                     price = 16000,
                     tax_amount = Tax.CalcTax(16000),
                     weight = 500,
                     quantity = 1,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 21,
                     isAvailable = true,
                     isDeleted = false
                 },
                 new ProductOptions
                 {
                     Id = 63,
                     price = 28000,
                     tax_amount = Tax.CalcTax(28000),
                     weight = 1000,
                     quantity = 2,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 21,
                     isAvailable = true,
                     isDeleted = false
                 }
            );
            modelBuilder.Entity<Invoices>().HasData(
             new Invoices
             {
                 Id = 1,
                 tax = 2400,
                 discount_code = null,
                 discount_percentage = 0,
                 shipping_fee = 3000,
                 total_before_discount = 16000,
                 total_paid = 16000,
                 UserID = 2,
                 created_at = Convert.ToDateTime("8/18/2019"),
                 updated_at = Convert.ToDateTime("10/12/2019 11:18:54 PM"),
             },
new Invoices
{
    Id = 2,
    tax = 3450,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 23000,
    total_paid = 23000,
    UserID = 5,
    created_at = Convert.ToDateTime("4/21/2019"),
    updated_at = Convert.ToDateTime("01/22/2019 11:20:02 PM"),
},
new Invoices
{
    Id = 3,
    tax = 11700,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 0,
    total_before_discount = 78000,
    total_paid = 78000,
    UserID = 3,
    created_at = Convert.ToDateTime("10/13/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:28:00 PM"),
},
new Invoices
{
    Id = 4,
    tax = 10050,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 67000,
    total_paid = 67000,
    UserID = 4,
    created_at = Convert.ToDateTime("1/4/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:28:27 PM"),
},
new Invoices
{
    Id = 5,
    tax = 5400,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 36000,
    total_paid = 36000,
    UserID = 4,
    created_at = Convert.ToDateTime("10/15/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:28:37 PM"),
},
new Invoices
{
    Id = 6,
    tax = 16800,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 0,
    total_before_discount = 112000,
    total_paid = 112000,
    UserID = 2,
    created_at = Convert.ToDateTime("3/26/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:28:47 PM"),
},
new Invoices
{
    Id = 7,
    tax = 12000,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 80000,
    total_paid = 80000,
    UserID = 2,
    created_at = Convert.ToDateTime("9/8/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:29:03 PM"),
},
new Invoices
{
    Id = 8,
    tax = 9600,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 0,
    total_before_discount = 64000,
    total_paid = 64000,
    UserID = 1,
    created_at = Convert.ToDateTime("3/1/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:29:29 PM"),
},
new Invoices
{
    Id = 9,
    tax = 9900,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 66000,
    total_paid = 66000,
    UserID = 4,
    created_at = Convert.ToDateTime("3/25/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:29:43 PM"),
},
new Invoices
{
    Id = 10,
    tax = 27000,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 0,
    total_before_discount = 180000,
    total_paid = 180000,
    UserID = 4,
    created_at = Convert.ToDateTime("6/3/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:29:55 PM"),
},
new Invoices
{
    Id = 11,
    tax = 3600,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 24000,
    total_paid = 24000,
    UserID = 3,
    created_at = Convert.ToDateTime("10/26/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:31:05 PM"),
},
new Invoices
{
    Id = 12,
    tax = 6750,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 45000,
    total_paid = 45000,
    UserID = 2,
    created_at = Convert.ToDateTime("9/21/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:31:13 PM"),
},
new Invoices
{
    Id = 13,
    tax = 6600,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 44000,
    total_paid = 44000,
    UserID = 4,
    created_at = Convert.ToDateTime("8/13/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:31:26 PM"),
},
new Invoices
{
    Id = 14,
    tax = 8400,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 0,
    total_before_discount = 56000,
    total_paid = 56000,
    UserID = 6,
    created_at = Convert.ToDateTime("8/11/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:31:32 PM"),
},
new Invoices
{
    Id = 15,
    tax = 4050,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 27000,
    total_paid = 27000,
    UserID = 2,
    created_at = Convert.ToDateTime("1/21/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:31:44 PM"),
},
new Invoices
{
    Id = 16,
    tax = 3300,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 22000,
    total_paid = 22000,
    UserID = 2,
    created_at = Convert.ToDateTime("4/8/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:33:49 PM"),
},
new Invoices
{
    Id = 17,
    tax = 5400,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 36000,
    total_paid = 36000,
    UserID = 5,
    created_at = Convert.ToDateTime("10/1/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:33:56 PM"),
},
new Invoices
{
    Id = 18,
    tax = 1500,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 10000,
    total_paid = 10000,
    UserID = 2,
    created_at = Convert.ToDateTime("3/12/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:34:15 PM"),
},
new Invoices
{
    Id = 19,
    tax = 4050,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 27000,
    total_paid = 27000,
    UserID = 5,
    created_at = Convert.ToDateTime("4/21/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:35:15 PM"),
},
new Invoices
{
    Id = 20,
    tax = 7320,
    discount_code = "15OFF",
    discount_percentage = 15,
    shipping_fee = 3000,
    total_before_discount = 57500,
    total_paid = 48875,
    UserID = 5,
    created_at = Convert.ToDateTime("1/14/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:35:44 PM"),
},
new Invoices
{
    Id = 21,
    tax = 1500,
    discount_code = null,
    discount_percentage = 0,
    shipping_fee = 3000,
    total_before_discount = 10000,
    total_paid = 10000,
    UserID = 2,
    created_at = Convert.ToDateTime("6/14/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:35:58 PM"),
},
new Invoices
{
    Id = 22,
    tax = 2550,
    discount_code = "15OFF",
    discount_percentage = 15,
    shipping_fee = 3000,
    total_before_discount = 20000,
    total_paid = 17000,
    UserID = 6,
    created_at = Convert.ToDateTime("4/27/2019"),
    updated_at = Convert.ToDateTime("10/22/2019 11:36:15 PM"),
}
                );
            modelBuilder.Entity<InvoiceItems>().HasData(
                new InvoiceItems
                {
                    Id = 1,
                    InvoiceID = 1,
                    ProductOptionID = 1,
                    prod_name = "ETHIOPIAN LIMU",
                    prod_desc = "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.",
                    prod_region = "Ethiopia",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "Arabic",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(8000),
                    opt_price = 8000,
                    opt_weight = 250,
                    quantity = 2,
                },
                new InvoiceItems
                {
                    Id = 2,
                    InvoiceID = 2,
                    ProductOptionID = 1,
                    prod_name = "ETHIOPIAN LIMU",
                    prod_desc = "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.",
                    prod_region = "Ethiopia",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "Arabic",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(8000),
                    opt_price = 8000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 3,
                    InvoiceID = 2,
                    ProductOptionID = 16,
                    prod_name = "Origin Coffee Roasting - Guatemala Santa Sofia",
                    prod_desc = "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.",
                    prod_region = "Guatamala",
                    prod_roast = "light",
                    prod_altitude_max = 1700,
                    prod_altitude_min = 1675,
                    prod_bean_type = "Primarily Caturra & Catuai",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(15000),
                    opt_price = 15000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 4,
                    InvoiceID = 3,
                    ProductOptionID = 26,
                    prod_name = "Rosetta Roastery - Honduras San Franscisco Natural",
                    prod_desc = "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.",
                    prod_region = "Honduras",
                    prod_roast = "Dark",
                    prod_altitude_max = 1600,
                    prod_altitude_min = 1420,
                    prod_bean_type = "Catui",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(26000),
                    opt_price = 26000,
                    opt_weight = 500,
                    quantity = 3,
                },
                new InvoiceItems
                {
                    Id = 5,
                    InvoiceID = 4,
                    ProductOptionID = 20,
                    prod_name = "Portland Project - Costa Rica Trojas",
                    prod_desc = "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.",
                    prod_region = "Costa Rica",
                    prod_roast = "Dark",
                    prod_altitude_max = 1600,
                    prod_altitude_min = 1220,
                    prod_bean_type = "Heirloom",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(19000),
                    opt_price = 19000,
                    opt_weight = 500,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 6,
                    InvoiceID = 4,
                    ProductOptionID = 34,
                    prod_name = "ETHIOPIAN LIMU",
                    prod_desc = "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.",
                    prod_region = "Ethiopia",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "Arabic",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(8000),
                    opt_price = 8000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 7,
                    InvoiceID = 4,
                    ProductOptionID = 56,
                    prod_name = "BRU Etheopia",
                    prod_desc = "A full bodied, sweet with fruity after taste. We roast this coffee medium-dark to maintain the complex flavours, a coffee that will place a smile on any connoisseurs face.",
                    prod_region = "Ethiopia",
                    prod_roast = "Medium",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "Arabica",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(40000),
                    opt_price = 40000,
                    opt_weight = 500,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 8,
                    InvoiceID = 5,
                    ProductOptionID = 30,
                    prod_name = "BURUNDI KIBIRA",
                    prod_desc = "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.Itâ€™s no secret that Burundi has the potential to produce great coffee.",
                    prod_region = "India",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "BVurundi",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(36000),
                    opt_price = 36000,
                    opt_weight = 1000,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 9,
                    InvoiceID = 6,
                    ProductOptionID = 33,
                    prod_name = "Truth. - India Single Origin",
                    prod_desc = "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.",
                    prod_region = "India",
                    prod_roast = "Medium",
                    prod_altitude_max = 1350,
                    prod_altitude_min = 1000,
                    prod_bean_type = "Cauvery",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(28000),
                    opt_price = 28000,
                    opt_weight = 1000,
                    quantity = 4,
                },
                new InvoiceItems
                {
                    Id = 10,
                    InvoiceID = 7,
                    ProductOptionID = 59,
                    prod_name = "Coffee Lab Alpha",
                    prod_desc = "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity",
                    prod_region = "South Africa",
                    prod_roast = "Dark",
                    prod_altitude_max = 10000,
                    prod_altitude_min = 9000,
                    prod_bean_type = "Catuai",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(20000),
                    opt_price = 20000,
                    opt_weight = 500,
                    quantity = 2,
                },
                new InvoiceItems
                {
                    Id = 11,
                    InvoiceID = 7,
                    ProductOptionID = 17,
                    prod_name = "Origin Coffee Roasting - Guatemala Santa Sofia",
                    prod_desc = "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.",
                    prod_region = "Guatamala",
                    prod_roast = "light",
                    prod_altitude_max = 1700,
                    prod_altitude_min = 1675,
                    prod_bean_type = "Primarily Caturra & Catuai",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(20000),
                    opt_price = 20000,
                    opt_weight = 500,
                    quantity = 2,
                },
                new InvoiceItems
                {
                    Id = 12,
                    InvoiceID = 8,
                    ProductOptionID = 15,
                    prod_name = "Legado - Bolivia Villa Rosario Organic",
                    prod_desc = "Villa Rosario is a colony in the Caranavi area of Yungus. The colony is located between 1550 and 1650 masl and is surrounded by jungle and small coffee farms.",
                    prod_region = "Bolivia",
                    prod_roast = "Dark",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "Arabic",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(16000),
                    opt_price = 16000,
                    opt_weight = 1000,
                    quantity = 4,
                },
                new InvoiceItems
                {
                    Id = 13,
                    InvoiceID = 9,
                    ProductOptionID = 29,
                    prod_name = "BURUNDI KIBIRA",
                    prod_desc = "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.Itâ€™s no secret that Burundi has the potential to produce great coffee.",
                    prod_region = "India",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "BVurundi",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(19000),
                    opt_price = 19000,
                    opt_weight = 500,
                    quantity = 2,
                },
                new InvoiceItems
                {
                    Id = 14,
                    InvoiceID = 9,
                    ProductOptionID = 36,
                    prod_name = "ETHIOPIAN LIMU",
                    prod_desc = "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.",
                    prod_region = "Ethiopia",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "Arabic",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(28000),
                    opt_price = 28000,
                    opt_weight = 1000,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 15,
                    InvoiceID = 10,
                    ProductOptionID = 45,
                    prod_name = "Rosetta Roastery - Honduras San Franscisco Natural",
                    prod_desc = "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.",
                    prod_region = "Marcala",
                    prod_roast = "Dark",
                    prod_altitude_max = 1600,
                    prod_altitude_min = 1550,
                    prod_bean_type = "Catuai",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(60000),
                    opt_price = 60000,
                    opt_weight = 1000,
                    quantity = 3,
                },
                new InvoiceItems
                {
                    Id = 16,
                    InvoiceID = 11,
                    ProductOptionID = 1,
                    prod_name = "ETHIOPIAN LIMU",
                    prod_desc = "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.",
                    prod_region = "Ethiopia",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "Arabic",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(8000),
                    opt_price = 8000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 17,
                    InvoiceID = 11,
                    ProductOptionID = 10,
                    prod_name = "Bean There - Blend 44",
                    prod_desc = "Bean There's Blend 44 combines their very popular Ethiopia Sidamo, and one of our favourites, their Burundi Musema & Nyarurama. The marriage of these two wonderful coffees yields everything you might want in a bold yet balanced coffee, suitable for manual brewing or espresso.",
                    prod_region = "Ethiopia",
                    prod_roast = "Light",
                    prod_altitude_max = 10000,
                    prod_altitude_min = 9500,
                    prod_bean_type = "Blend",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(6000),
                    opt_price = 6000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 18,
                    InvoiceID = 11,
                    ProductOptionID = 19,
                    prod_name = "Portland Project - Costa Rica Trojas",
                    prod_desc = "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.",
                    prod_region = "Costa Rica",
                    prod_roast = "Dark",
                    prod_altitude_max = 1600,
                    prod_altitude_min = 1220,
                    prod_bean_type = "Heirloom",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(10000),
                    opt_price = 10000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 19,
                    InvoiceID = 12,
                    ProductOptionID = 32,
                    prod_name = "Truth. - India Single Origin",
                    prod_desc = "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.",
                    prod_region = "India",
                    prod_roast = "Medium",
                    prod_altitude_max = 1350,
                    prod_altitude_min = 1000,
                    prod_bean_type = "Cauvery",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(15000),
                    opt_price = 15000,
                    opt_weight = 500,
                    quantity = 3,
                },
                new InvoiceItems
                {
                    Id = 20,
                    InvoiceID = 13,
                    ProductOptionID = 24,
                    prod_name = "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot",
                    prod_desc = "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.",
                    prod_region = "Nicaragua",
                    prod_roast = "Medium",
                    prod_altitude_max = 1200,
                    prod_altitude_min = 1100,
                    prod_bean_type = "Finca Idealista",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(17000),
                    opt_price = 17000,
                    opt_weight = 1000,
                    quantity = 2,
                },
                new InvoiceItems
                {
                    Id = 21,
                    InvoiceID = 13,
                    ProductOptionID = 19,
                    prod_name = "Portland Project - Costa Rica Trojas",
                    prod_desc = "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.",
                    prod_region = "Costa Rica",
                    prod_roast = "Dark",
                    prod_altitude_max = 1600,
                    prod_altitude_min = 1220,
                    prod_bean_type = "Heirloom",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(10000),
                    opt_price = 10000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 22,
                    InvoiceID = 14,
                    ProductOptionID = 36,
                    prod_name = "ETHIOPIAN LIMU",
                    prod_desc = "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.",
                    prod_region = "Ethiopia",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "Arabic",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(28000),
                    opt_price = 28000,
                    opt_weight = 1000,
                    quantity = 2,
                },
                new InvoiceItems
                {
                    Id = 23,
                    InvoiceID = 15,
                    ProductOptionID = 4,
                    prod_name = "Truth. - Ethiopia Guji",
                    prod_desc = "Guji is one of those regions of Ethiopia that have garnered much more attention in recent years, competing with the classically popular areas like Yirgacheffe & Limu.",
                    prod_region = "Ethiopia",
                    prod_roast = "Medium",
                    prod_altitude_max = 2500,
                    prod_altitude_min = 2000,
                    prod_bean_type = "Hierloom",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(9000),
                    opt_price = 9000,
                    opt_weight = 250,
                    quantity = 3,
                },
                new InvoiceItems
                {
                    Id = 24,
                    InvoiceID = 16,
                    ProductOptionID = 8,
                    prod_name = "Truth. - Burundi",
                    prod_desc = "Truth seems to have had a bit of a love affair with Burundian coffee in the last few years, one from which we have all benefited. They've had a streak of delicious examples of the up and coming coffee producing country's very best exports that we have thoroughly enjoyed.",
                    prod_region = "Burundi",
                    prod_roast = "light",
                    prod_altitude_max = 1800,
                    prod_altitude_min = 1600,
                    prod_bean_type = "Arabic",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(22000),
                    opt_price = 22000,
                    opt_weight = 500,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 25,
                    InvoiceID = 17,
                    ProductOptionID = 58,
                    prod_name = "Coffee Lab Alpha",
                    prod_desc = "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity",
                    prod_region = "South Africa",
                    prod_roast = "Dark",
                    prod_altitude_max = 10000,
                    prod_altitude_min = 9000,
                    prod_bean_type = "Catuai",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(12000),
                    opt_price = 12000,
                    opt_weight = 250,
                    quantity = 3,
                },
                new InvoiceItems
                {
                    Id = 26,
                    InvoiceID = 18,
                    ProductOptionID = 28,
                    prod_name = "BURUNDI KIBIRA",
                    prod_desc = "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.Itâ€™s no secret that Burundi has the potential to produce great coffee.",
                    prod_region = "India",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "BVurundi",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(10000),
                    opt_price = 10000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 27,
                    InvoiceID = 19,
                    ProductOptionID = 23,
                    prod_name = "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot",
                    prod_desc = "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.",
                    prod_region = "Nicaragua",
                    prod_roast = "Medium",
                    prod_altitude_max = 1200,
                    prod_altitude_min = 1100,
                    prod_bean_type = "Finca Idealista",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(13500),
                    opt_price = 13500,
                    opt_weight = 500,
                    quantity = 2,
                },
                new InvoiceItems
                {
                    Id = 28,
                    InvoiceID = 20,
                    ProductOptionID = 30,
                    prod_name = "BURUNDI KIBIRA",
                    prod_desc = "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.Itâ€™s no secret that Burundi has the potential to produce great coffee.",
                    prod_region = "India",
                    prod_roast = "light",
                    prod_altitude_max = 9000,
                    prod_altitude_min = 7000,
                    prod_bean_type = "BVurundi",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(36000),
                    opt_price = 36000,
                    opt_weight = 1000,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 29,
                    InvoiceID = 20,
                    ProductOptionID = 31,
                    prod_name = "Truth. - India Single Origin",
                    prod_desc = "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.",
                    prod_region = "India",
                    prod_roast = "Medium",
                    prod_altitude_max = 1350,
                    prod_altitude_min = 1000,
                    prod_bean_type = "Cauvery",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(8000),
                    opt_price = 8000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 30,
                    InvoiceID = 20,
                    ProductOptionID = 23,
                    prod_name = "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot",
                    prod_desc = "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.",
                    prod_region = "Nicaragua",
                    prod_roast = "Medium",
                    prod_altitude_max = 1200,
                    prod_altitude_min = 1100,
                    prod_bean_type = "Finca Idealista",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(13500),
                    opt_price = 13500,
                    opt_weight = 500,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 31,
                    InvoiceID = 21,
                    ProductOptionID = 19,
                    prod_name = "Portland Project - Costa Rica Trojas",
                    prod_desc = "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.",
                    prod_region = "Costa Rica",
                    prod_roast = "Dark",
                    prod_altitude_max = 1600,
                    prod_altitude_min = 1220,
                    prod_bean_type = "Heirloom",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(10000),
                    opt_price = 10000,
                    opt_weight = 250,
                    quantity = 1,
                },
                new InvoiceItems
                {
                    Id = 32,
                    InvoiceID = 22,
                    ProductOptionID = 17,
                    prod_name = "Origin Coffee Roasting - Guatemala Santa Sofia",
                    prod_desc = "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.",
                    prod_region = "Guatamala",
                    prod_roast = "light",
                    prod_altitude_max = 1700,
                    prod_altitude_min = 1675,
                    prod_bean_type = "Primarily Caturra & Catuai",
                    prod_image_url = "404.jpg",
                    opt_tax_amount = Tax.CalcTax(20000),
                    opt_price = 20000,
                    opt_weight = 500,
                    quantity = 1,
                }
                );
        }

    }
}
