using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class seed : Migration
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
                    isFreeShipping = table.Column<byte>(type: "tinyint", nullable: false),
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
                table: "Products",
                columns: new[] { "Id", "altitude_max", "altitude_min", "bean_type", "created_at", "desc", "image_url", "isDeleted", "max_price", "min_price", "name", "region", "roast", "updated_at" },
                values: new object[,]
                {
                    { 1, 9000, 7000, "Arabic", new DateTime(2019, 10, 16, 0, 37, 29, 491, DateTimeKind.Local).AddTicks(7101), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 16, 0, 37, 29, 492, DateTimeKind.Local).AddTicks(8290) },
                    { 19, 9000, 7000, "Arabica", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(695), "A full bodied, sweet with fruity after taste. We roast this coffee medium-dark to maintain the complex flavours, a coffee that will place a smile on any connoisseurs face.", "404.jpg", (byte)0, 50000, 32000, "BRU Etheopia", "Ethiopia", "Medium", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(696) },
                    { 18, 9000, 7000, "Harrar", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(693), "Heavy-bodied, spicy and fragrant, Ethiopian Harrar coffee is a wild and exotic dry processed (natural) Arabica coffee that is grown on small farms in the Oromia region (formerly Harrar) in southern Ethiopia at elevations between 1,400 meters and 2,000 meters.", "404.jpg", (byte)0, 21200, 15100, "ETHIOPIAN HARRAR", "Ethiopia", "Medium", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(693) },
                    { 17, 9000, 7000, "Blend", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(690), "Tribe Coffee's Espresso Blend has quickly earned them a reputation in and around Cape Town. Full-bodied and well-developed, it makes great milk & espresso-based drinks which is why you'll find it in many restaurants and cafés in the Mother City!", "404.jpg", (byte)0, 45500, 22000, "Tribe Coffee - Espresso Blend", "SouthAfrica", "Dark", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(691) },
                    { 16, 9000, 7000, "Blend", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(688), "häzz coffee is a rich and subtle, truly modern blend of South American and African origin, suitable for any palate.  It offers an exceptionally wide range of aromas, accompanied by a bold but round and smooth body.In 2012, it won a Gold Medal at the annual International Coffee Tasting in Italy.", "404.jpg", (byte)0, 30000, 12500, "hazz blend - coffee for heroes", "South America and Africa", "light", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(689) },
                    { 15, 1600, 1550, "Catuai", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(686), "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", (byte)0, 60000, 16000, "Rosetta Roastery - Honduras San Franscisco Natural", "Marcala", "Dark", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(687) },
                    { 14, 1200, 1100, "Blend", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(684), "This blend was concocted early one morning when there just wasn't enough of one of the components, and a certain CCTeam member thought, 'what the heck ?'  And so, a blend was born, and it tasted like fruit salad in a cup. It kind of makes sense in the end if you think about it.", "404.jpg", (byte)0, 26000, 12500, "Fruit Salad Cape Coffee Blend", "South Afica", "Medium", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(685) },
                    { 13, 2000, 1700, "Red Bourbon", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(682), "Rwanda Musasa is a returning favourite from Origin Coffee Roasting. Highly celebrated, the Musasa Dukunde Kawa Cooperative is known all over the world for its top quality Red Bourbon beans.", "404.jpg", (byte)0, 28000, 8000, "Origin Coffee Roasting - Rwanda Musasa Ruli", "Ruli", "light", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(682) },
                    { 12, 9000, 7000, "Arabic", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(679), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(680) },
                    { 20, 10000, 9000, "Catuai", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(697), "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity", "404.jpg", (byte)0, 30000, 12000, "Coffee Lab Alpha", "South Africa", "Dark", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(699) },
                    { 11, 1350, 1000, "Cauvery", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(677), "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.", "404.jpg", (byte)0, 28000, 8000, "Truth. - India Single Origin", "India", "Medium", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(678) },
                    { 9, 1600, 1420, "Catui", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(673), "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", (byte)0, 32000, 18000, "Rosetta Roastery - Honduras San Franscisco Natural", "Honduras", "Dark", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(673) },
                    { 8, 1200, 1100, "Finca Idealista", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(670), "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.", "404.jpg", (byte)0, 17000, 10000, "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot", "Nicaragua", "Medium", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(670) },
                    { 7, 1600, 1220, "Heirloom", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(668), "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.", "404.jpg", (byte)0, 29000, 10000, "Portland Project - Costa Rica Trojas", "Costa Rica", "Dark", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(668) },
                    { 6, 1700, 1675, "Primarily Caturra & Catuai", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(664), "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.", "404.jpg", (byte)0, 35000, 15000, "Origin Coffee Roasting - Guatemala Santa Sofia", "Guatamala", "light", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(665) },
                    { 5, 9000, 7000, "Arabic", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(662), "Villa Rosario is a colony in the Caranavi area of Yungus. The colony is located between 1550 and 1650 masl and is surrounded by jungle and small coffee farms.", "404.jpg", (byte)0, 16000, 8000, "Legado - Bolivia Villa Rosario Organic", "Bolivia", "Dark", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(663) },
                    { 4, 10000, 9500, "Blend", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(660), "Bean There's Blend 44 combines their very popular Ethiopia Sidamo, and one of our favourites, their Burundi Musema & Nyarurama. The marriage of these two wonderful coffees yields everything you might want in a bold yet balanced coffee, suitable for manual brewing or espresso.", "404.jpg", (byte)0, 25000, 6000, "Bean There - Blend 44", "Ethiopia", "Light", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(660) },
                    { 3, 1800, 1600, "Arabic", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(657), "Truth seems to have had a bit of a love affair with Burundian coffee in the last few years, one from which we have all benefited. They've had a streak of delicious examples of the up and coming coffee producing country's very best exports that we have thoroughly enjoyed.", "404.jpg", (byte)0, 32000, 10000, "Truth. - Burundi", "Burundi", "light", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(658) },
                    { 2, 2500, 2000, "Hierloom", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(637), "Guji is one of those regions of Ethiopia that have garnered much more attention in recent years, competing with the classically popular areas like Yirgacheffe & Limu.", "404.jpg", (byte)0, 31000, 9000, "Truth. - Ethiopia Guji", "Ethiopia", "Medium", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(649) },
                    { 10, 9000, 7000, "BVurundi", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(675), "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.It’s no secret that Burundi has the potential to produce great coffee.", "404.jpg", (byte)0, 36000, 10000, "BURUNDI KIBIRA", "India", "light", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(675) },
                    { 21, 5000, 3500, "Arabic", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(701), "Turkish Coffee ground to the finest Powder with a touch of elachi spice for that exotic flavour.", "404.jpg", (byte)0, 28000, 8000, "Titanium Coffee Turkish", "Turkish", "Dark", new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(701) }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "ProductID", "created_at", "isAvailable", "isDeleted", "price", "quantity", "updated_at", "weight" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(6568), (byte)1, (byte)0, 8000, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(7096), 250 },
                    { 34, 12, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8762), (byte)1, (byte)0, 8000, 6, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8763), 250 },
                    { 35, 12, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8764), (byte)1, (byte)0, 15000, 7, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8765), 500 },
                    { 36, 12, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8766), (byte)1, (byte)0, 28000, 8, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8767), 1000 },
                    { 37, 13, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8768), (byte)1, (byte)0, 8000, 22, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8769), 250 },
                    { 38, 13, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8770), (byte)1, (byte)0, 15000, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8771), 500 },
                    { 39, 13, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8772), (byte)1, (byte)0, 28000, 44, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8772), 1000 },
                    { 40, 14, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8773), (byte)1, (byte)0, 12500, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8774), 250 },
                    { 41, 14, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8776), (byte)1, (byte)0, 18000, 16, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8776), 500 },
                    { 42, 14, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8778), (byte)1, (byte)0, 26000, 17, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8780), 1000 },
                    { 43, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8781), (byte)1, (byte)0, 16000, 12, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8782), 250 },
                    { 44, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8783), (byte)1, (byte)0, 32000, 22, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8783), 500 },
                    { 45, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8784), (byte)1, (byte)0, 60000, 26, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8785), 1000 },
                    { 46, 16, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8786), (byte)1, (byte)0, 12500, 4, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8787), 250 },
                    { 33, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8760), (byte)1, (byte)0, 28000, 33, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8761), 1000 },
                    { 47, 16, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8788), (byte)1, (byte)0, 17000, 22, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8788), 500 },
                    { 49, 17, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8791), (byte)1, (byte)0, 22000, 21, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8791), 250 },
                    { 50, 17, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8793), (byte)1, (byte)0, 31000, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8793), 500 },
                    { 51, 17, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8794), (byte)1, (byte)0, 45500, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8795), 1000 },
                    { 52, 18, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8796), (byte)1, (byte)0, 15100, 22, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8796), 250 },
                    { 53, 18, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8797), (byte)1, (byte)0, 18000, 12, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8798), 500 },
                    { 54, 18, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8799), (byte)1, (byte)0, 21200, 32, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8800), 1000 },
                    { 55, 19, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8801), (byte)1, (byte)0, 32000, 21, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8801), 250 },
                    { 56, 19, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8802), (byte)1, (byte)0, 40000, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8803), 500 },
                    { 57, 19, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8804), (byte)1, (byte)0, 50000, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8805), 1000 },
                    { 58, 20, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8806), (byte)1, (byte)0, 12000, 44, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8806), 250 },
                    { 59, 20, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8807), (byte)1, (byte)0, 20000, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8808), 500 },
                    { 60, 20, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8809), (byte)1, (byte)0, 30000, 21, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8810), 1000 },
                    { 61, 21, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8811), (byte)1, (byte)0, 8000, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8811), 250 },
                    { 48, 16, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8789), (byte)1, (byte)0, 30000, 9, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8790), 1000 },
                    { 62, 21, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8873), (byte)1, (byte)0, 16000, 1, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8874), 500 },
                    { 32, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8758), (byte)1, (byte)0, 15000, 13, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8759), 500 },
                    { 30, 10, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8755), (byte)1, (byte)0, 36000, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8755), 1000 },
                    { 2, 1, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8690), (byte)1, (byte)0, 15000, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8694), 500 },
                    { 3, 1, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8707), (byte)1, (byte)0, 28000, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8708), 1000 },
                    { 4, 2, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8710), (byte)1, (byte)0, 9000, 10, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8710), 250 },
                    { 5, 2, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8711), (byte)1, (byte)0, 15000, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8712), 500 },
                    { 6, 2, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8713), (byte)1, (byte)0, 31000, 12, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8714), 1000 },
                    { 7, 3, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8715), (byte)1, (byte)0, 10000, 13, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8715), 250 },
                    { 8, 3, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8716), (byte)1, (byte)0, 22000, 25, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8717), 500 },
                    { 9, 3, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8718), (byte)1, (byte)0, 32000, 5, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8719), 1000 },
                    { 10, 4, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8720), (byte)1, (byte)0, 6000, 13, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8721), 250 },
                    { 11, 4, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8722), (byte)1, (byte)0, 14000, 35, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8722), 500 },
                    { 12, 4, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8723), (byte)1, (byte)0, 25000, 19, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8724), 1000 },
                    { 13, 5, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8725), (byte)1, (byte)0, 8000, 16, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8726), 250 },
                    { 14, 5, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8727), (byte)1, (byte)0, 12000, 17, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8727), 500 },
                    { 31, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8756), (byte)1, (byte)0, 8000, 7, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8757), 250 },
                    { 15, 5, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8728), (byte)1, (byte)0, 16000, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8729), 1000 },
                    { 17, 6, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8732), (byte)1, (byte)0, 20000, 25, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8732), 500 },
                    { 18, 6, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8733), (byte)1, (byte)0, 35000, 19, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8734), 1000 },
                    { 19, 7, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8735), (byte)1, (byte)0, 10000, 16, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8736), 250 },
                    { 20, 7, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8737), (byte)1, (byte)0, 19000, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8739), 500 },
                    { 21, 7, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8740), (byte)1, (byte)0, 29000, 17, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8740), 1000 },
                    { 22, 8, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8742), (byte)1, (byte)0, 10000, 17, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8742), 250 },
                    { 23, 8, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8743), (byte)1, (byte)0, 13500, 13, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8744), 500 },
                    { 24, 8, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8745), (byte)1, (byte)0, 17000, 25, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8745), 1000 },
                    { 25, 9, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8746), (byte)1, (byte)0, 18000, 35, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8747), 250 },
                    { 26, 9, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8748), (byte)1, (byte)0, 26000, 11, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8749), 500 },
                    { 27, 9, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8750), (byte)1, (byte)0, 32000, 9, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8750), 1000 },
                    { 28, 10, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8751), (byte)1, (byte)0, 10000, 15, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8752), 250 },
                    { 29, 10, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8753), (byte)1, (byte)0, 19000, 21, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8754), 500 },
                    { 16, 6, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8730), (byte)1, (byte)0, 15000, 33, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8730), 250 },
                    { 63, 21, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8875), (byte)1, (byte)0, 28000, 2, new DateTime(2019, 10, 16, 0, 37, 29, 493, DateTimeKind.Local).AddTicks(8876), 1000 }
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
