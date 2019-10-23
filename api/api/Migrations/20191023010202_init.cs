using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(255)", nullable: false),
                    percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    desc = table.Column<string>(type: "varchar(1000)", nullable: false),
                    region = table.Column<string>(type: "varchar(255)", nullable: false),
                    max_price = table.Column<int>(type: "int", nullable: false),
                    min_price = table.Column<int>(type: "int", nullable: false),
                    roast = table.Column<string>(type: "varchar(255)", nullable: false),
                    altitude_max = table.Column<int>(type: "int", nullable: false),
                    altitude_min = table.Column<int>(type: "int", nullable: false),
                    bean_type = table.Column<string>(type: "varchar(255)", nullable: false),
                    image_url = table.Column<string>(type: "varchar(255)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDeleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false),
                    contact_number = table.Column<string>(type: "varchar(20)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    isActive = table.Column<byte>(type: "tinyint", nullable: false),
                    isDelted = table.Column<byte>(type: "tinyint", nullable: false),
                    isAdmin = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    price = table.Column<int>(type: "int", nullable: false),
                    tax_amount = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    isAvailable = table.Column<byte>(type: "tinyint", nullable: false),
                    isDeleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptions_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tax = table.Column<int>(type: "int", nullable: false),
                    discount_code = table.Column<string>(type: "varchar(255)", nullable: true),
                    discount_percentage = table.Column<int>(type: "int", nullable: false),
                    shipping_fee = table.Column<int>(type: "int", nullable: false),
                    total_before_discount = table.Column<int>(type: "int", nullable: false),
                    total_paid = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(type: "int", nullable: false),
                    ProductOptionID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ProductOptions_ProductOptionID",
                        column: x => x.ProductOptionID,
                        principalTable: "ProductOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    ProductOptionID = table.Column<int>(type: "int", nullable: false),
                    prod_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_desc = table.Column<string>(type: "varchar(1000)", nullable: false),
                    prod_region = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_roast = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_altitude_max = table.Column<int>(type: "int", nullable: false),
                    prod_altitude_min = table.Column<int>(type: "int", nullable: false),
                    prod_bean_type = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_image_url = table.Column<string>(type: "varchar(255)", nullable: false),
                    opt_tax_amount = table.Column<int>(type: "int", nullable: false),
                    opt_price = table.Column<int>(type: "int", nullable: false),
                    opt_weight = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiscountCodes",
                columns: new[] { "Id", "code", "percentage" },
                values: new object[] { 1, "15OFF", 15 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "altitude_max", "altitude_min", "bean_type", "created_at", "desc", "image_url", "isDeleted", "max_price", "min_price", "name", "region", "roast", "updated_at" },
                values: new object[,]
                {
                    { 21, 5000, 3500, "Arabic", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6720), "Turkish Coffee ground to the finest Powder with a touch of elachi spice for that exotic flavour.", "404.jpg", (byte)0, 28000, 8000, "Titanium Coffee Turkish", "Turkish", "Dark", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6721) },
                    { 20, 10000, 9000, "Catuai", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6718), "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity", "404.jpg", (byte)0, 30000, 12000, "Coffee Lab Alpha", "South Africa", "Dark", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6719) },
                    { 19, 9000, 7000, "Arabica", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6716), "A full bodied, sweet with fruity after taste. We roast this coffee medium-dark to maintain the complex flavours, a coffee that will place a smile on any connoisseurs face.", "404.jpg", (byte)0, 50000, 32000, "BRU Etheopia", "Ethiopia", "Medium", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6717) },
                    { 18, 9000, 7000, "Harrar", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6714), "Heavy-bodied, spicy and fragrant, Ethiopian Harrar coffee is a wild and exotic dry processed (natural) Arabica coffee that is grown on small farms in the Oromia region (formerly Harrar) in southern Ethiopia at elevations between 1,400 meters and 2,000 meters.", "404.jpg", (byte)0, 21200, 15100, "ETHIOPIAN HARRAR", "Ethiopia", "Medium", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6714) },
                    { 17, 9000, 7000, "Blend", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6712), "Tribe Coffee's Espresso Blend has quickly earned them a reputation in and around Cape Town. Full-bodied and well-developed, it makes great milk & espresso-based drinks which is why you'll find it in many restaurants and cafés in the Mother City!", "404.jpg", (byte)0, 45500, 22000, "Tribe Coffee - Espresso Blend", "SouthAfrica", "Dark", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6712) },
                    { 16, 9000, 7000, "Blend", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6709), "häzz coffee is a rich and subtle, truly modern blend of South American and African origin, suitable for any palate.  It offers an exceptionally wide range of aromas, accompanied by a bold but round and smooth body.In 2012, it won a Gold Medal at the annual International Coffee Tasting in Italy.", "404.jpg", (byte)0, 30000, 12500, "hazz blend - coffee for heroes", "South America and Africa", "light", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6709) },
                    { 15, 1600, 1550, "Catuai", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6707), "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", (byte)0, 60000, 16000, "Rosetta Roastery - Honduras San Franscisco Natural", "Marcala", "Dark", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6707) },
                    { 14, 1200, 1100, "Blend", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6705), "This blend was concocted early one morning when there just wasn't enough of one of the components, and a certain CCTeam member thought, 'what the heck ?'  And so, a blend was born, and it tasted like fruit salad in a cup. It kind of makes sense in the end if you think about it.", "404.jpg", (byte)0, 26000, 12500, "Fruit Salad Cape Coffee Blend", "South Afica", "Medium", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6705) },
                    { 12, 9000, 7000, "Arabic", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6700), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6701) },
                    { 11, 1350, 1000, "Cauvery", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6698), "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.", "404.jpg", (byte)0, 28000, 8000, "Truth. - India Single Origin", "India", "Medium", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6699) },
                    { 13, 2000, 1700, "Red Bourbon", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6702), "Rwanda Musasa is a returning favourite from Origin Coffee Roasting. Highly celebrated, the Musasa Dukunde Kawa Cooperative is known all over the world for its top quality Red Bourbon beans.", "404.jpg", (byte)0, 28000, 8000, "Origin Coffee Roasting - Rwanda Musasa Ruli", "Ruli", "light", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6703) },
                    { 9, 1600, 1420, "Catui", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6694), "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", (byte)0, 32000, 18000, "Rosetta Roastery - Honduras San Franscisco Natural", "Honduras", "Dark", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6695) },
                    { 8, 1200, 1100, "Finca Idealista", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6692), "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.", "404.jpg", (byte)0, 17000, 10000, "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot", "Nicaragua", "Medium", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6692) },
                    { 7, 1600, 1220, "Heirloom", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6690), "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.", "404.jpg", (byte)0, 29000, 10000, "Portland Project - Costa Rica Trojas", "Costa Rica", "Dark", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6690) },
                    { 6, 1700, 1675, "Primarily Caturra & Catuai", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6687), "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.", "404.jpg", (byte)0, 35000, 15000, "Origin Coffee Roasting - Guatemala Santa Sofia", "Guatamala", "light", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6687) },
                    { 5, 9000, 7000, "Arabic", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6685), "Villa Rosario is a colony in the Caranavi area of Yungus. The colony is located between 1550 and 1650 masl and is surrounded by jungle and small coffee farms.", "404.jpg", (byte)0, 16000, 8000, "Legado - Bolivia Villa Rosario Organic", "Bolivia", "Dark", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6685) },
                    { 4, 10000, 9500, "Blend", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6683), "Bean There's Blend 44 combines their very popular Ethiopia Sidamo, and one of our favourites, their Burundi Musema & Nyarurama. The marriage of these two wonderful coffees yields everything you might want in a bold yet balanced coffee, suitable for manual brewing or espresso.", "404.jpg", (byte)0, 25000, 6000, "Bean There - Blend 44", "Ethiopia", "Light", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6683) },
                    { 3, 1800, 1600, "Arabic", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6680), "Truth seems to have had a bit of a love affair with Burundian coffee in the last few years, one from which we have all benefited. They've had a streak of delicious examples of the up and coming coffee producing country's very best exports that we have thoroughly enjoyed.", "404.jpg", (byte)0, 32000, 10000, "Truth. - Burundi", "Burundi", "light", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6681) },
                    { 2, 2500, 2000, "Hierloom", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6667), "Guji is one of those regions of Ethiopia that have garnered much more attention in recent years, competing with the classically popular areas like Yirgacheffe & Limu.", "404.jpg", (byte)0, 31000, 9000, "Truth. - Ethiopia Guji", "Ethiopia", "Medium", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6672) },
                    { 1, 9000, 7000, "Arabic", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(266), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(5987) },
                    { 10, 9000, 7000, "BVurundi", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6696), "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.It’s no secret that Burundi has the potential to produce great coffee.", "404.jpg", (byte)0, 36000, 10000, "BURUNDI KIBIRA", "India", "light", new DateTime(2019, 10, 23, 3, 2, 1, 840, DateTimeKind.Local).AddTicks(6697) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "contact_number", "created_at", "email", "first_name", "isActive", "isAdmin", "isDelted", "last_name", "password", "updated_at", "username" },
                values: new object[,]
                {
                    { 5, "0726664432", new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noizing@yahoo.com", "Nikita", (byte)1, (byte)0, (byte)0, "van der Merwe", "cc9928dbbd1ba4803064cf22530c30409de3c2b8c222eb7956ad50e5e4ec6872", new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noizing" },
                    { 1, "0728291496	", new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "fluffy@gmail.com", "Andrew", (byte)1, (byte)1, (byte)0, "Walls", "00fcdde26dd77af7858a52e3913e6f3330a32b3121a61bce915cc6145fc44453", new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fluffy" },
                    { 2, "0821111111", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton@gmail.com", "Anton", (byte)1, (byte)1, (byte)0, "Röscher", "b786fbda93a09a3d4df30b3f021679abb16c6e2cd1384586cbb1d76049a474bc", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anton" },
                    { 3, "0821113333", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thom@gmail.com", "Thomas", (byte)1, (byte)1, (byte)0, "McAlpine", "9e8e9dcc20b56023a0ce12400ef1dce7e151f48caec39fd276d908e3593fb280", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minimac" },
                    { 4, "0724444444", new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "jimbo@gmail.com", "Jimbo", (byte)1, (byte)0, (byte)0, "Botswane", "f8fd9810608bd6eee15cb8de8290c161c1b6a503e03cd5607ecfc56f2213ab6a", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jimmy" },
                    { 6, "0821113333", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "picka@uj.ac.za", "Prince", (byte)1, (byte)0, (byte)0, "Thabotsa", "e22854c624ce2c6a18064a0247411174b5991ceb6e035472e872927370a21a99", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "pillies" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "UserID", "created_at", "discount_code", "discount_percentage", "shipping_fee", "tax", "total_before_discount", "total_paid", "updated_at" },
                values: new object[,]
                {
                    { 22, 6, new DateTime(2019, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "15OFF", 15, 3000, 2550, 20000, 17000, new DateTime(2019, 10, 22, 23, 36, 15, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 2400, 16000, 16000, new DateTime(2019, 10, 12, 23, 18, 54, 0, DateTimeKind.Unspecified) },
                    { 6, 2, new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 16800, 112000, 112000, new DateTime(2019, 10, 22, 23, 28, 47, 0, DateTimeKind.Unspecified) },
                    { 7, 2, new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 12000, 80000, 80000, new DateTime(2019, 10, 22, 23, 29, 3, 0, DateTimeKind.Unspecified) },
                    { 12, 2, new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 6750, 45000, 45000, new DateTime(2019, 10, 22, 23, 31, 13, 0, DateTimeKind.Unspecified) },
                    { 15, 2, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 4050, 27000, 27000, new DateTime(2019, 10, 22, 23, 31, 44, 0, DateTimeKind.Unspecified) },
                    { 16, 2, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 3300, 22000, 22000, new DateTime(2019, 10, 22, 23, 33, 49, 0, DateTimeKind.Unspecified) },
                    { 18, 2, new DateTime(2019, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 1500, 10000, 10000, new DateTime(2019, 10, 22, 23, 34, 15, 0, DateTimeKind.Unspecified) },
                    { 21, 2, new DateTime(2019, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 1500, 10000, 10000, new DateTime(2019, 10, 22, 23, 35, 58, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 11700, 78000, 78000, new DateTime(2019, 10, 22, 23, 28, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 9600, 64000, 64000, new DateTime(2019, 10, 22, 23, 29, 29, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 10050, 67000, 67000, new DateTime(2019, 10, 22, 23, 28, 27, 0, DateTimeKind.Unspecified) },
                    { 11, 3, new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 3600, 24000, 24000, new DateTime(2019, 10, 22, 23, 31, 5, 0, DateTimeKind.Unspecified) },
                    { 20, 5, new DateTime(2019, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "15OFF", 15, 3000, 7320, 57500, 48875, new DateTime(2019, 10, 22, 23, 35, 44, 0, DateTimeKind.Unspecified) },
                    { 19, 5, new DateTime(2019, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 4050, 27000, 27000, new DateTime(2019, 10, 22, 23, 35, 15, 0, DateTimeKind.Unspecified) },
                    { 17, 5, new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 5400, 36000, 36000, new DateTime(2019, 10, 22, 23, 33, 56, 0, DateTimeKind.Unspecified) },
                    { 14, 6, new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 8400, 56000, 56000, new DateTime(2019, 10, 22, 23, 31, 32, 0, DateTimeKind.Unspecified) },
                    { 13, 4, new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 6600, 44000, 44000, new DateTime(2019, 10, 22, 23, 31, 26, 0, DateTimeKind.Unspecified) },
                    { 10, 4, new DateTime(2019, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 27000, 180000, 180000, new DateTime(2019, 10, 22, 23, 29, 55, 0, DateTimeKind.Unspecified) },
                    { 9, 4, new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 9900, 66000, 66000, new DateTime(2019, 10, 22, 23, 29, 43, 0, DateTimeKind.Unspecified) },
                    { 5, 4, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 5400, 36000, 36000, new DateTime(2019, 10, 22, 23, 28, 37, 0, DateTimeKind.Unspecified) },
                    { 2, 5, new DateTime(2019, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3000, 3450, 23000, 23000, new DateTime(2019, 1, 22, 23, 20, 2, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "ProductID", "created_at", "isAvailable", "isDeleted", "price", "quantity", "tax_amount", "updated_at", "weight" },
                values: new object[,]
                {
                    { 45, 15, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2046), (byte)1, (byte)0, 60000, 26, 9000, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2046), 1000 },
                    { 46, 16, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2048), (byte)1, (byte)0, 12500, 4, 1875, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2048), 250 },
                    { 47, 16, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2049), (byte)1, (byte)0, 17000, 22, 2550, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2050), 500 },
                    { 48, 16, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2051), (byte)1, (byte)0, 30000, 9, 4500, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2052), 1000 },
                    { 49, 17, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2053), (byte)1, (byte)0, 22000, 21, 3300, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2053), 250 },
                    { 50, 17, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2055), (byte)1, (byte)0, 31000, 11, 4650, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2055), 500 },
                    { 51, 17, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2056), (byte)1, (byte)0, 45500, 11, 6825, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2057), 1000 },
                    { 52, 18, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2058), (byte)1, (byte)0, 15100, 22, 2265, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2059), 250 },
                    { 53, 18, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2060), (byte)1, (byte)0, 18000, 12, 2700, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2061), 500 },
                    { 55, 19, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2064), (byte)1, (byte)0, 32000, 21, 4800, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2064), 250 },
                    { 56, 19, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2065), (byte)1, (byte)0, 40000, 11, 6000, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2066), 500 },
                    { 57, 19, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2067), (byte)1, (byte)0, 50000, 15, 7500, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2068), 1000 },
                    { 59, 20, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2071), (byte)1, (byte)0, 20000, 15, 3000, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2071), 500 },
                    { 60, 20, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2073), (byte)1, (byte)0, 30000, 21, 4500, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2073), 1000 },
                    { 61, 21, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2074), (byte)1, (byte)0, 8000, 11, 1200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2075), 250 },
                    { 62, 21, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2076), (byte)1, (byte)0, 16000, 1, 2400, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2077), 500 },
                    { 63, 21, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2078), (byte)1, (byte)0, 28000, 2, 4200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2079), 1000 },
                    { 44, 15, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2044), (byte)1, (byte)0, 32000, 22, 4800, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2044), 500 },
                    { 54, 18, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2062), (byte)1, (byte)0, 21200, 32, 3180, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2062), 1000 },
                    { 58, 20, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2069), (byte)1, (byte)0, 12000, 44, 1800, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2070), 250 },
                    { 43, 15, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2042), (byte)1, (byte)0, 16000, 12, 2400, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2043), 250 },
                    { 41, 14, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2039), (byte)1, (byte)0, 18000, 16, 2700, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2039), 500 },
                    { 18, 6, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1934), (byte)1, (byte)0, 35000, 19, 5250, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1935), 1000 },
                    { 17, 6, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1933), (byte)1, (byte)0, 20000, 25, 3000, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1933), 500 },
                    { 16, 6, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1930), (byte)1, (byte)0, 15000, 33, 2250, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1931), 250 },
                    { 15, 5, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1928), (byte)1, (byte)0, 16000, 11, 2400, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1929), 1000 },
                    { 14, 5, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1927), (byte)1, (byte)0, 12000, 17, 1800, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1927), 500 },
                    { 13, 5, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1925), (byte)1, (byte)0, 8000, 16, 1200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1925), 250 },
                    { 12, 4, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1923), (byte)1, (byte)0, 25000, 19, 3750, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1924), 1000 },
                    { 11, 4, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1921), (byte)1, (byte)0, 14000, 35, 2100, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1922), 500 },
                    { 10, 4, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1919), (byte)1, (byte)0, 6000, 13, 900, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1920), 250 },
                    { 9, 3, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1918), (byte)1, (byte)0, 32000, 5, 4800, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1918), 1000 },
                    { 8, 3, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1915), (byte)1, (byte)0, 22000, 25, 3300, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1916), 500 },
                    { 7, 3, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1914), (byte)1, (byte)0, 10000, 13, 1500, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1914), 250 },
                    { 6, 2, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1912), (byte)1, (byte)0, 31000, 12, 4650, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1912), 1000 },
                    { 5, 2, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1910), (byte)1, (byte)0, 15000, 11, 2250, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1911), 500 },
                    { 4, 2, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1908), (byte)1, (byte)0, 9000, 10, 1350, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1909), 250 },
                    { 3, 1, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1906), (byte)1, (byte)0, 28000, 15, 4200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1907), 1000 },
                    { 2, 1, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1888), (byte)1, (byte)0, 15000, 15, 2250, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1893), 500 },
                    { 19, 7, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1936), (byte)1, (byte)0, 10000, 16, 1500, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1937), 250 },
                    { 20, 7, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1938), (byte)1, (byte)0, 19000, 15, 2850, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1939), 500 },
                    { 21, 7, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1941), (byte)1, (byte)0, 29000, 17, 4350, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1941), 1000 },
                    { 22, 8, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1942), (byte)1, (byte)0, 10000, 17, 1500, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1943), 250 },
                    { 40, 14, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2037), (byte)1, (byte)0, 12500, 15, 1875, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2037), 250 },
                    { 39, 13, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2035), (byte)1, (byte)0, 28000, 44, 4200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2035), 1000 },
                    { 38, 13, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2033), (byte)1, (byte)0, 15000, 11, 2250, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2033), 500 },
                    { 37, 13, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2031), (byte)1, (byte)0, 8000, 22, 1200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2032), 250 },
                    { 36, 12, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2029), (byte)1, (byte)0, 28000, 8, 4200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2030), 1000 },
                    { 35, 12, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2027), (byte)1, (byte)0, 15000, 7, 2250, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2028), 500 },
                    { 34, 12, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2026), (byte)1, (byte)0, 8000, 6, 1200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2026), 250 },
                    { 33, 11, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2024), (byte)1, (byte)0, 28000, 33, 4200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2024), 1000 },
                    { 42, 14, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2040), (byte)1, (byte)0, 26000, 17, 3900, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2041), 1000 },
                    { 32, 11, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2022), (byte)1, (byte)0, 15000, 13, 2250, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2023), 500 },
                    { 30, 10, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2019), (byte)1, (byte)0, 36000, 11, 5400, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2019), 1000 },
                    { 29, 10, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2017), (byte)1, (byte)0, 19000, 21, 2850, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2017), 500 },
                    { 28, 10, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2015), (byte)1, (byte)0, 10000, 15, 1500, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2015), 250 },
                    { 27, 9, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2013), (byte)1, (byte)0, 32000, 9, 4800, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2014), 1000 },
                    { 26, 9, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2011), (byte)1, (byte)0, 26000, 11, 3900, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2012), 500 },
                    { 25, 9, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2009), (byte)1, (byte)0, 18000, 35, 2700, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2010), 250 },
                    { 24, 8, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1946), (byte)1, (byte)0, 17000, 25, 2550, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1946), 1000 },
                    { 23, 8, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1944), (byte)1, (byte)0, 13500, 13, 2025, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(1945), 500 },
                    { 31, 11, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2020), (byte)1, (byte)0, 8000, 7, 1200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(2021), 250 },
                    { 1, 1, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(468), (byte)1, (byte)0, 8000, 15, 1200, new DateTime(2019, 10, 23, 3, 2, 1, 841, DateTimeKind.Local).AddTicks(853), 250 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "Id", "InvoiceID", "ProductOptionID", "opt_price", "opt_tax_amount", "opt_weight", "prod_altitude_max", "prod_altitude_min", "prod_bean_type", "prod_desc", "prod_image_url", "prod_name", "prod_region", "prod_roast", "quantity" },
                values: new object[,]
                {
                    { 12, 8, 15, 16000, 2400, 1000, 9000, 7000, "Arabic", "Villa Rosario is a colony in the Caranavi area of Yungus. The colony is located between 1550 and 1650 masl and is surrounded by jungle and small coffee farms.", "404.jpg", "Legado - Bolivia Villa Rosario Organic", "Bolivia", "Dark", 4 },
                    { 30, 20, 23, 13500, 2025, 500, 1200, 1100, "Finca Idealista", "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.", "404.jpg", "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot", "Nicaragua", "Medium", 1 },
                    { 29, 20, 31, 8000, 1200, 250, 1350, 1000, "Cauvery", "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.", "404.jpg", "Truth. - India Single Origin", "India", "Medium", 1 },
                    { 28, 20, 30, 36000, 5400, 1000, 9000, 7000, "BVurundi", "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.Itâ€™s no secret that Burundi has the potential to produce great coffee.", "404.jpg", "BURUNDI KIBIRA", "India", "light", 1 },
                    { 27, 19, 23, 13500, 2025, 500, 1200, 1100, "Finca Idealista", "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.", "404.jpg", "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot", "Nicaragua", "Medium", 2 },
                    { 25, 17, 58, 12000, 1800, 250, 10000, 9000, "Catuai", "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity", "404.jpg", "Coffee Lab Alpha", "South Africa", "Dark", 3 },
                    { 3, 2, 16, 15000, 2250, 250, 1700, 1675, "Primarily Caturra & Catuai", "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.", "404.jpg", "Origin Coffee Roasting - Guatemala Santa Sofia", "Guatamala", "light", 1 },
                    { 2, 2, 1, 8000, 1200, 250, 9000, 7000, "Arabic", "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", "ETHIOPIAN LIMU", "Ethiopia", "light", 1 },
                    { 21, 13, 19, 10000, 1500, 250, 1600, 1220, "Heirloom", "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.", "404.jpg", "Portland Project - Costa Rica Trojas", "Costa Rica", "Dark", 1 },
                    { 20, 13, 24, 17000, 2550, 1000, 1200, 1100, "Finca Idealista", "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.", "404.jpg", "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot", "Nicaragua", "Medium", 2 },
                    { 15, 10, 45, 60000, 9000, 1000, 1600, 1550, "Catuai", "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", "Rosetta Roastery - Honduras San Franscisco Natural", "Marcala", "Dark", 3 },
                    { 14, 9, 36, 28000, 4200, 1000, 9000, 7000, "Arabic", "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", "ETHIOPIAN LIMU", "Ethiopia", "light", 1 },
                    { 13, 9, 29, 19000, 2850, 500, 9000, 7000, "BVurundi", "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.Itâ€™s no secret that Burundi has the potential to produce great coffee.", "404.jpg", "BURUNDI KIBIRA", "India", "light", 2 },
                    { 8, 5, 30, 36000, 5400, 1000, 9000, 7000, "BVurundi", "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.Itâ€™s no secret that Burundi has the potential to produce great coffee.", "404.jpg", "BURUNDI KIBIRA", "India", "light", 1 },
                    { 7, 4, 56, 40000, 6000, 500, 9000, 7000, "Arabica", "A full bodied, sweet with fruity after taste. We roast this coffee medium-dark to maintain the complex flavours, a coffee that will place a smile on any connoisseurs face.", "404.jpg", "BRU Etheopia", "Ethiopia", "Medium", 1 },
                    { 6, 4, 34, 8000, 1200, 250, 9000, 7000, "Arabic", "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", "ETHIOPIAN LIMU", "Ethiopia", "light", 1 },
                    { 5, 4, 20, 19000, 2850, 500, 1600, 1220, "Heirloom", "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.", "404.jpg", "Portland Project - Costa Rica Trojas", "Costa Rica", "Dark", 1 },
                    { 18, 11, 19, 10000, 1500, 250, 1600, 1220, "Heirloom", "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.", "404.jpg", "Portland Project - Costa Rica Trojas", "Costa Rica", "Dark", 1 },
                    { 17, 11, 10, 6000, 900, 250, 10000, 9500, "Blend", "Bean There's Blend 44 combines their very popular Ethiopia Sidamo, and one of our favourites, their Burundi Musema & Nyarurama. The marriage of these two wonderful coffees yields everything you might want in a bold yet balanced coffee, suitable for manual brewing or espresso.", "404.jpg", "Bean There - Blend 44", "Ethiopia", "Light", 1 },
                    { 16, 11, 1, 8000, 1200, 250, 9000, 7000, "Arabic", "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", "ETHIOPIAN LIMU", "Ethiopia", "light", 1 },
                    { 4, 3, 26, 26000, 3900, 500, 1600, 1420, "Catui", "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", "Rosetta Roastery - Honduras San Franscisco Natural", "Honduras", "Dark", 3 },
                    { 31, 21, 19, 10000, 1500, 250, 1600, 1220, "Heirloom", "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.", "404.jpg", "Portland Project - Costa Rica Trojas", "Costa Rica", "Dark", 1 },
                    { 26, 18, 28, 10000, 1500, 250, 9000, 7000, "BVurundi", "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.Itâ€™s no secret that Burundi has the potential to produce great coffee.", "404.jpg", "BURUNDI KIBIRA", "India", "light", 1 },
                    { 24, 16, 8, 22000, 3300, 500, 1800, 1600, "Arabic", "Truth seems to have had a bit of a love affair with Burundian coffee in the last few years, one from which we have all benefited. They've had a streak of delicious examples of the up and coming coffee producing country's very best exports that we have thoroughly enjoyed.", "404.jpg", "Truth. - Burundi", "Burundi", "light", 1 },
                    { 23, 15, 4, 9000, 1350, 250, 2500, 2000, "Hierloom", "Guji is one of those regions of Ethiopia that have garnered much more attention in recent years, competing with the classically popular areas like Yirgacheffe & Limu.", "404.jpg", "Truth. - Ethiopia Guji", "Ethiopia", "Medium", 3 },
                    { 19, 12, 32, 15000, 2250, 500, 1350, 1000, "Cauvery", "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.", "404.jpg", "Truth. - India Single Origin", "India", "Medium", 3 },
                    { 11, 7, 17, 20000, 3000, 500, 1700, 1675, "Primarily Caturra & Catuai", "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.", "404.jpg", "Origin Coffee Roasting - Guatemala Santa Sofia", "Guatamala", "light", 2 },
                    { 10, 7, 59, 20000, 3000, 500, 10000, 9000, "Catuai", "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity", "404.jpg", "Coffee Lab Alpha", "South Africa", "Dark", 2 },
                    { 9, 6, 33, 28000, 4200, 1000, 1350, 1000, "Cauvery", "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.", "404.jpg", "Truth. - India Single Origin", "India", "Medium", 4 },
                    { 1, 1, 1, 8000, 1200, 250, 9000, 7000, "Arabic", "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", "ETHIOPIAN LIMU", "Ethiopia", "light", 2 },
                    { 22, 14, 36, 28000, 4200, 1000, 9000, 7000, "Arabic", "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", "ETHIOPIAN LIMU", "Ethiopia", "light", 2 },
                    { 32, 22, 17, 20000, 3000, 500, 1700, 1675, "Primarily Caturra & Catuai", "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.", "404.jpg", "Origin Coffee Roasting - Guatemala Santa Sofia", "Guatamala", "light", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserID",
                table: "Cart",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductOptionID",
                table: "CartItems",
                column: "ProductOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceID",
                table: "InvoiceItems",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserID",
                table: "Invoices",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_ProductID",
                table: "ProductOptions",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ProductOptions");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
