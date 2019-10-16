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
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tax = table.Column<int>(type: "int", nullable: false),
                    discount_code = table.Column<string>(type: "varchar(255)", nullable: true),
                    discount_percentage = table.Column<int>(type: "int", nullable: false),
                    isExpressShipping = table.Column<byte>(type: "tinyint", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
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
                    { 19, 9000, 7000, "Arabica", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2450), "A full bodied, sweet with fruity after taste. We roast this coffee medium-dark to maintain the complex flavours, a coffee that will place a smile on any connoisseurs face.", "404.jpg", (byte)0, 50000, 32000, "BRU Etheopia", "Ethiopia", "Medium", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2450) },
                    { 18, 9000, 7000, "Harrar", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2448), "Heavy-bodied, spicy and fragrant, Ethiopian Harrar coffee is a wild and exotic dry processed (natural) Arabica coffee that is grown on small farms in the Oromia region (formerly Harrar) in southern Ethiopia at elevations between 1,400 meters and 2,000 meters.", "404.jpg", (byte)0, 21200, 15100, "ETHIOPIAN HARRAR", "Ethiopia", "Medium", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2448) },
                    { 17, 9000, 7000, "Blend", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2445), "Tribe Coffee's Espresso Blend has quickly earned them a reputation in and around Cape Town. Full-bodied and well-developed, it makes great milk & espresso-based drinks which is why you'll find it in many restaurants and cafés in the Mother City!", "404.jpg", (byte)0, 45500, 22000, "Tribe Coffee - Espresso Blend", "SouthAfrica", "Dark", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2446) },
                    { 16, 9000, 7000, "Blend", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2443), "häzz coffee is a rich and subtle, truly modern blend of South American and African origin, suitable for any palate.  It offers an exceptionally wide range of aromas, accompanied by a bold but round and smooth body.In 2012, it won a Gold Medal at the annual International Coffee Tasting in Italy.", "404.jpg", (byte)0, 30000, 12500, "hazz blend - coffee for heroes", "South America and Africa", "light", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2444) },
                    { 15, 1600, 1550, "Catuai", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2441), "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", (byte)0, 60000, 16000, "Rosetta Roastery - Honduras San Franscisco Natural", "Marcala", "Dark", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2442) },
                    { 14, 1200, 1100, "Blend", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2439), "This blend was concocted early one morning when there just wasn't enough of one of the components, and a certain CCTeam member thought, 'what the heck ?'  And so, a blend was born, and it tasted like fruit salad in a cup. It kind of makes sense in the end if you think about it.", "404.jpg", (byte)0, 26000, 12500, "Fruit Salad Cape Coffee Blend", "South Afica", "Medium", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2439) },
                    { 13, 2000, 1700, "Red Bourbon", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2437), "Rwanda Musasa is a returning favourite from Origin Coffee Roasting. Highly celebrated, the Musasa Dukunde Kawa Cooperative is known all over the world for its top quality Red Bourbon beans.", "404.jpg", (byte)0, 28000, 8000, "Origin Coffee Roasting - Rwanda Musasa Ruli", "Ruli", "light", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2437) },
                    { 12, 9000, 7000, "Arabic", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2435), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2435) },
                    { 11, 1350, 1000, "Cauvery", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2433), "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.", "404.jpg", (byte)0, 28000, 8000, "Truth. - India Single Origin", "India", "Medium", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2433) },
                    { 10, 9000, 7000, "BVurundi", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2430), "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.It’s no secret that Burundi has the potential to produce great coffee.", "404.jpg", (byte)0, 36000, 10000, "BURUNDI KIBIRA", "India", "light", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2431) },
                    { 9, 1600, 1420, "Catui", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2428), "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", (byte)0, 32000, 18000, "Rosetta Roastery - Honduras San Franscisco Natural", "Honduras", "Dark", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2428) },
                    { 8, 1200, 1100, "Finca Idealista", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2426), "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.", "404.jpg", (byte)0, 17000, 10000, "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot", "Nicaragua", "Medium", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2426) },
                    { 7, 1600, 1220, "Heirloom", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2423), "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.", "404.jpg", (byte)0, 29000, 10000, "Portland Project - Costa Rica Trojas", "Costa Rica", "Dark", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2424) },
                    { 6, 1700, 1675, "Primarily Caturra & Catuai", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2421), "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.", "404.jpg", (byte)0, 35000, 15000, "Origin Coffee Roasting - Guatemala Santa Sofia", "Guatamala", "light", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2422) },
                    { 5, 9000, 7000, "Arabic", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2326), "Villa Rosario is a colony in the Caranavi area of Yungus. The colony is located between 1550 and 1650 masl and is surrounded by jungle and small coffee farms.", "404.jpg", (byte)0, 16000, 8000, "Legado - Bolivia Villa Rosario Organic", "Bolivia", "Dark", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2419) },
                    { 4, 10000, 9500, "Blend", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2324), "Bean There's Blend 44 combines their very popular Ethiopia Sidamo, and one of our favourites, their Burundi Musema & Nyarurama. The marriage of these two wonderful coffees yields everything you might want in a bold yet balanced coffee, suitable for manual brewing or espresso.", "404.jpg", (byte)0, 25000, 6000, "Bean There - Blend 44", "Ethiopia", "Light", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2324) },
                    { 3, 1800, 1600, "Arabic", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2321), "Truth seems to have had a bit of a love affair with Burundian coffee in the last few years, one from which we have all benefited. They've had a streak of delicious examples of the up and coming coffee producing country's very best exports that we have thoroughly enjoyed.", "404.jpg", (byte)0, 32000, 10000, "Truth. - Burundi", "Burundi", "light", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2322) },
                    { 2, 2500, 2000, "Hierloom", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2307), "Guji is one of those regions of Ethiopia that have garnered much more attention in recent years, competing with the classically popular areas like Yirgacheffe & Limu.", "404.jpg", (byte)0, 31000, 9000, "Truth. - Ethiopia Guji", "Ethiopia", "Medium", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2312) },
                    { 1, 9000, 7000, "Arabic", new DateTime(2019, 10, 16, 2, 46, 3, 467, DateTimeKind.Local).AddTicks(5477), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(545) },
                    { 20, 10000, 9000, "Catuai", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2452), "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity", "404.jpg", (byte)0, 30000, 12000, "Coffee Lab Alpha", "South Africa", "Dark", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2452) },
                    { 21, 5000, 3500, "Arabic", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2454), "Turkish Coffee ground to the finest Powder with a touch of elachi spice for that exotic flavour.", "404.jpg", (byte)0, 28000, 8000, "Titanium Coffee Turkish", "Turkish", "Dark", new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(2454) }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "ProductID", "created_at", "isAvailable", "isDeleted", "price", "quantity", "updated_at", "weight" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(5521), (byte)1, (byte)0, 8000, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(5936), 250 },
                    { 34, 12, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7467), (byte)1, (byte)0, 8000, 6, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7467), 250 },
                    { 35, 12, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7468), (byte)1, (byte)0, 15000, 7, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7469), 500 },
                    { 36, 12, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7470), (byte)1, (byte)0, 28000, 8, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7470), 1000 },
                    { 37, 13, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7472), (byte)1, (byte)0, 8000, 22, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7472), 250 },
                    { 38, 13, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7473), (byte)1, (byte)0, 15000, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7474), 500 },
                    { 39, 13, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7475), (byte)1, (byte)0, 28000, 44, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7475), 1000 },
                    { 40, 14, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7477), (byte)1, (byte)0, 12500, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7477), 250 },
                    { 41, 14, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7478), (byte)1, (byte)0, 18000, 16, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7479), 500 },
                    { 42, 14, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7480), (byte)1, (byte)0, 26000, 17, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7480), 1000 },
                    { 43, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7539), (byte)1, (byte)0, 16000, 12, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7540), 250 },
                    { 44, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7541), (byte)1, (byte)0, 32000, 22, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7542), 500 },
                    { 45, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7543), (byte)1, (byte)0, 60000, 26, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7543), 1000 },
                    { 46, 16, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7544), (byte)1, (byte)0, 12500, 4, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7545), 250 },
                    { 33, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7465), (byte)1, (byte)0, 28000, 33, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7466), 1000 },
                    { 47, 16, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7546), (byte)1, (byte)0, 17000, 22, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7547), 500 },
                    { 49, 17, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7549), (byte)1, (byte)0, 22000, 21, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7550), 250 },
                    { 50, 17, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7551), (byte)1, (byte)0, 31000, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7552), 500 },
                    { 51, 17, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7553), (byte)1, (byte)0, 45500, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7553), 1000 },
                    { 52, 18, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7554), (byte)1, (byte)0, 15100, 22, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7555), 250 },
                    { 53, 18, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7556), (byte)1, (byte)0, 18000, 12, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7556), 500 },
                    { 54, 18, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7558), (byte)1, (byte)0, 21200, 32, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7558), 1000 },
                    { 55, 19, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7559), (byte)1, (byte)0, 32000, 21, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7560), 250 },
                    { 56, 19, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7561), (byte)1, (byte)0, 40000, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7561), 500 },
                    { 57, 19, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7563), (byte)1, (byte)0, 50000, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7563), 1000 },
                    { 58, 20, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7564), (byte)1, (byte)0, 12000, 44, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7565), 250 },
                    { 59, 20, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7566), (byte)1, (byte)0, 20000, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7566), 500 },
                    { 60, 20, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7567), (byte)1, (byte)0, 30000, 21, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7568), 1000 },
                    { 61, 21, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7569), (byte)1, (byte)0, 8000, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7570), 250 },
                    { 48, 16, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7548), (byte)1, (byte)0, 30000, 9, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7548), 1000 },
                    { 62, 21, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7571), (byte)1, (byte)0, 16000, 1, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7571), 500 },
                    { 32, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7463), (byte)1, (byte)0, 15000, 13, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7464), 500 },
                    { 30, 10, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7460), (byte)1, (byte)0, 36000, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7461), 1000 },
                    { 2, 1, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7398), (byte)1, (byte)0, 15000, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7402), 500 },
                    { 3, 1, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7415), (byte)1, (byte)0, 28000, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7416), 1000 },
                    { 4, 2, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7417), (byte)1, (byte)0, 9000, 10, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7418), 250 },
                    { 5, 2, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7419), (byte)1, (byte)0, 15000, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7419), 500 },
                    { 6, 2, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7420), (byte)1, (byte)0, 31000, 12, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7421), 1000 },
                    { 7, 3, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7422), (byte)1, (byte)0, 10000, 13, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7423), 250 },
                    { 8, 3, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7424), (byte)1, (byte)0, 22000, 25, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7424), 500 },
                    { 9, 3, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7425), (byte)1, (byte)0, 32000, 5, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7426), 1000 },
                    { 10, 4, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7427), (byte)1, (byte)0, 6000, 13, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7428), 250 },
                    { 11, 4, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7429), (byte)1, (byte)0, 14000, 35, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7429), 500 },
                    { 12, 4, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7430), (byte)1, (byte)0, 25000, 19, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7431), 1000 },
                    { 13, 5, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7432), (byte)1, (byte)0, 8000, 16, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7432), 250 },
                    { 14, 5, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7433), (byte)1, (byte)0, 12000, 17, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7434), 500 },
                    { 31, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7462), (byte)1, (byte)0, 8000, 7, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7462), 250 },
                    { 15, 5, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7435), (byte)1, (byte)0, 16000, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7436), 1000 },
                    { 17, 6, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7438), (byte)1, (byte)0, 20000, 25, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7439), 500 },
                    { 18, 6, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7440), (byte)1, (byte)0, 35000, 19, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7440), 1000 },
                    { 19, 7, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7442), (byte)1, (byte)0, 10000, 16, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7442), 250 },
                    { 20, 7, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7443), (byte)1, (byte)0, 19000, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7444), 500 },
                    { 21, 7, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7445), (byte)1, (byte)0, 29000, 17, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7445), 1000 },
                    { 22, 8, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7446), (byte)1, (byte)0, 10000, 17, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7447), 250 },
                    { 23, 8, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7448), (byte)1, (byte)0, 13500, 13, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7448), 500 },
                    { 24, 8, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7450), (byte)1, (byte)0, 17000, 25, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7450), 1000 },
                    { 25, 9, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7452), (byte)1, (byte)0, 18000, 35, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7452), 250 },
                    { 26, 9, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7454), (byte)1, (byte)0, 26000, 11, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7454), 500 },
                    { 27, 9, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7455), (byte)1, (byte)0, 32000, 9, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7456), 1000 },
                    { 28, 10, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7457), (byte)1, (byte)0, 10000, 15, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7457), 250 },
                    { 29, 10, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7458), (byte)1, (byte)0, 19000, 21, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7459), 500 },
                    { 16, 6, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7437), (byte)1, (byte)0, 15000, 33, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7437), 250 },
                    { 63, 21, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7572), (byte)1, (byte)0, 28000, 2, new DateTime(2019, 10, 16, 2, 46, 3, 468, DateTimeKind.Local).AddTicks(7573), 1000 }
                });

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
                name: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

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
