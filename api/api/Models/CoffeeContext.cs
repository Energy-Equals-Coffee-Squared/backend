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
                },

                new Products
                {
                    Id = 2,
                    name = "Truth. - Ethiopia Guji",
                    desc = "Guji is one of those regions of Ethiopia that have garnered much more " +
                    "attention in recent years, competing with the classically popular areas like Yirgacheffe " +
                    "& Limu. We've had the privilege of tasting quite a few coffees from the Guji region, many " +
                    "of which we have enjoyed. This new example from Truth is consistently delicious, but quite" +
                    " different in terms of its flavour profile.",
                    max_price = 31000,
                    min_price = 9000,
                    region = "Ethiopia",
                    roast = "Medium",
                    altitude_max = 2500,
                    altitude_min = 2000,
                    bean_type = "Hierloom",
                    image_url = "404.jpg",
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
                    image_url = "404.jpg",
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
                    "everything you might want in a bold yet balanced coffee, suitable for manual brewing or espresso." +
                    " We particularly enjoyed it in plungers and moka pots.",
                    max_price = 25000,
                    min_price = 6000,
                    region = "Ethiopia",
                    roast = "Light",
                    altitude_max = 10000,
                    altitude_min = 9500,
                    bean_type = "Blend",
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 5,
                    name = "Legado - Bolivia Villa Rosario Organic",
                    desc = "Villa Rosario is a colony in the Caranavi area of Yungus. The colony is located between 1550 and 1650 masl and is surrounded by " +
                    "jungle and small coffee farms. After the land reforms in the 1950s the Bolivian government encouraged people from the Altiplano and La Paz " +
                    "to move down to the tropical agricultural areas to farm coffee by giving them free parcels of land.",
                    max_price = 16000,
                    min_price = 8000,
                    region = "Bolivia",
                    roast = "Dark",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Arabic",
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 6,
                    name = "Origin Coffee Roasting - Guatemala Santa Sofia",
                    desc = "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a " +
                    "chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities. Origin's decafs always work well as espresso, " +
                    "but you may also enjoy it in filter methods.",
                    max_price = 35000,
                    min_price = 15000,
                    region = "Guatamala",
                    roast = "light",
                    altitude_max = 1700,
                    altitude_min = 1675,
                    bean_type = "Primarily Caturra & Catuai",
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 7,
                    name = "Portland Project - Costa Rica Trojas",
                    desc = "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee " +
                    "growing world. Its acidity is very discrete and body is full and satisfying. You'll find many of those nutty notes that people love in Latin " +
                    "American coffees, but there's also a sweetness that comes through that may remind you of caramelised or candied nuts.",
                    max_price = 29000,
                    min_price = 10000,
                    region = "Costa Rica",
                    roast = "Dark",
                    altitude_max = 1600,
                    altitude_min = 1220,
                    bean_type = "Heirloom",
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 8,
                    name = "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot",
                    desc = "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed. Specifically, it underwent an extended anaerobic fermentation which pioneers are speculating will have a big impact on the acidity of coffees." +
                    ,
                    max_price = 17000,
                    min_price = 10000,
                    region = "Nicaragua",
                    roast = "Medium",
                    altitude_max = 1200,
                    altitude_min = 1100,
                    bean_type = "Finca Idealista",
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 9,
                    name = "Rosetta Roastery - Honduras San Franscisco Natural",
                    desc = "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, " +
                    "at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles. This Honduras " +
                    "is anything but reserved.",
                    max_price = 32000,
                    min_price = 18000,
                    region = "Honduras",
                    roast = "Dark",
                    altitude_max = 1600,
                    altitude_min = 1420,
                    bean_type = "Catui",
                    image_url = "404.jpg",
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
                    image_url = "404.jpg",
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
                    image_url = "404.jpg",
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
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 13,
                    name = "Origin Coffee Roasting - Rwanda Musasa Ruli",
                    desc = "Rwanda Musasa is a returning favourite from Origin Coffee Roasting. Highly celebrated, the Musasa Dukunde Kawa Cooperative is known " +
                    "all over the world for its top quality Red Bourbon beans. Every year, our friends at Origin manage to secure one of its best lots, and always " +
                    "bring out wonderful flavours to enjoy through their masterful roasts.",
                    max_price = 28000,
                    min_price = 8000,
                    region = "Ruli",
                    roast = "light",
                    altitude_max = 2000,
                    altitude_min = 1700,
                    bean_type = "Red Bourbon",
                    image_url = "404.jpg",
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
                    "think about it. You take the wonderful caramel sweetness and orange notes of Quaffee's Colombia Los Idolos, and you combine it with bold " +
                    "blueberry and dark grape flavours of Rosetta's Honduras San Franscisco Natural. In retrospect it's to be expected: Fruit Salad.",
                    max_price = 26000,
                    min_price = 12500,
                    region = "South Afica",
                    roast = "Medium",
                    altitude_max = 1200,
                    altitude_min = 1100,
                    bean_type = "Blend",
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 15,
                    name = "Rosetta Roastery - Honduras San Franscisco Natural",
                    desc = "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least" +
                    " here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles. This Honduras is anything" +
                    " but reserved" +
                    "Our first taste of this coffee was actually in a MoccaMaster filter brew. We were immediately captivated by the intense flavours of blueberry.",
                    max_price = 60000,
                    min_price = 16000,
                    region = "Marcala",
                    roast = "Dark",
                    altitude_max = 1600,
                    altitude_min = 1550,
                    bean_type = "Catuai",
                    image_url = "404.jpg",
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
                    "In 2012, it won a Gold Medal at the annual International Coffee Tasting in Italy. Every batch is freshly roasted to perfection with the " +
                    "utmost care. Try it first without sugar – it's that good! A reward for all aspirant heroes.",
                    max_price = 30000,
                    min_price = 12500,
                    region = "South America and Africa",
                    roast = "light",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Blend",
                    image_url = "404.jpg",
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
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 18,
                    name = "ETHIOPIAN HARRAR",
                    desc = "Heavy-bodied, spicy and fragrant, Ethiopian Harrar coffee is a wild and exotic dry processed (natural) Arabica coffee that is " +
                    "grown on small farms in the Oromia region (formerly Harrar) in southern Ethiopia at elevations between 1,400 meters and 2,000 meters. " +
                    "The province of Harrar, is east of Addis Ababa, the country’s capitol.",
                    max_price = 21200,
                    min_price = 15100,
                    region = "Ethiopia",
                    roast = "Medium",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Harrar",
                    image_url = "404.jpg",
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isDeleted = false
                },

                new Products
                {
                    Id = 19,
                    name = "BRU Etheopia",
                    desc = "A full bodied, sweet with fruity after taste. We roast this coffee medium-dark to maintain the complex flavours, a coffee" +
                    " that will place a smile on any connoisseur's face.",
                    max_price = 50000,
                    min_price = 32000,
                    region = "Ethiopia",
                    roast = "Medium",
                    altitude_max = 9000,
                    altitude_min = 7000,
                    bean_type = "Arabica",
                    image_url = "404.jpg",
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
                    image_url = "404.jpg",
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
                 },

                 new ProductOptions
                 {
                     Id = 1,
                     price = 9000,
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
                     Id = 2,
                     price = 15000,
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
                     Id = 3,
                     price = 31000,
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
                     Id = 1,
                     price = 10000,
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
                     Id = 2,
                     price = 22000,
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
                     Id = 3,
                     price = 32000,
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
                     Id = 1,
                     price = 6000,
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
                     Id = 2,
                     price = 14000,
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
                     Id = 3,
                     price = 25000,
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
                     Id = 1,
                     price = 8000,
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
                     Id = 2,
                     price = 12000,
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
                     Id = 3,
                     price = 16000,
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
                     Id = 1,
                     price = 15000,
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
                     Id = 2,
                     price = 20000,
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
                     Id = 3,
                     price = 35000,
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
                     Id = 1,
                     price = 10000,
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
                     Id = 2,
                     price = 19000,
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
                     Id = 3,
                     price = 29000,
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
                     Id = 1,
                     price = 10000,
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
                     Id = 2,
                     price = 13500,
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
                     Id = 3,
                     price = 17000,
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
                     Id = 1,
                     price = 18000,
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
                     Id = 2,
                     price = 26000,
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
                     Id = 3,
                     price = 32000,
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
                     Id = 1,
                     price = 10000,
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
                     Id = 2,
                     price = 19000,
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
                     Id = 3,
                     price = 36000,
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
                     Id = 1,
                     price = 8000,
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
                     Id = 2,
                     price = 15000,
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
                     Id = 3,
                     price = 28000,
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
                     Id = 1,
                     price = 8000,
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
                     Id = 2,
                     price = 15000,
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
                     Id = 3,
                     price = 28000,
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
                     Id = 1,
                     price = 8000,
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
                     Id = 2,
                     price = 15000,
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
                     Id = 3,
                     price = 28000,
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
                     Id = 1,
                     price = 12500,
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
                     Id = 2,
                     price = 18000,
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
                     Id = 3,
                     price = 26000,
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
                     Id = 1,
                     price = 16000,
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
                     Id = 2,
                     price = 32000,
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
                     Id = 3,
                     price = 60000,
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
                     Id = 1,
                     price = 12500,
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
                     Id = 2,
                     price = 17000,
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
                     Id = 3,
                     price = 30000,
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
                     Id = 1,
                     price = 22000,
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
                     Id = 2,
                     price = 31000,
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
                     Id = 3,
                     price = 45500,
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
                     Id = 1,
                     price = 15100,
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
                     Id = 2,
                     price = 18000,
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
                     Id = 3,
                     price = 21200,
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
                     Id = 1,
                     price = 32000,
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
                     Id = 2,
                     price = 40000,
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
                     Id = 3,
                     price = 50000,
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
                     Id = 1,
                     price = 12000,
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
                     Id = 2,
                     price = 20000,
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
                     Id = 3,
                     price = 30000,
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
                     Id = 1,
                     price = 8000,
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
                     Id = 2,
                     price = 16000,
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
                     Id = 3,
                     price = 28000,
                     weight = 1000,
                     quantity = 2,
                     created_at = DateTime.Now,
                     updated_at = DateTime.Now,
                     ProductID = 21,
                     isAvailable = true,
                     isDeleted = false
                 }
            );
        }

    }
}
