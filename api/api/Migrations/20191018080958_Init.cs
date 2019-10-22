using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Init : Migration
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
                    shipping_fee = table.Column<byte>(type: "tinyint", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
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
                    { 19, 9000, 7000, "Arabica", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9065), "A full bodied, sweet with fruity after taste. We roast this coffee medium-dark to maintain the complex flavours, a coffee that will place a smile on any connoisseurs face.", "404.jpg", (byte)0, 50000, 32000, "BRU Etheopia", "Ethiopia", "Medium", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9065) },
                    { 18, 9000, 7000, "Harrar", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9063), "Heavy-bodied, spicy and fragrant, Ethiopian Harrar coffee is a wild and exotic dry processed (natural) Arabica coffee that is grown on small farms in the Oromia region (formerly Harrar) in southern Ethiopia at elevations between 1,400 meters and 2,000 meters.", "404.jpg", (byte)0, 21200, 15100, "ETHIOPIAN HARRAR", "Ethiopia", "Medium", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9063) },
                    { 17, 9000, 7000, "Blend", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9061), "Tribe Coffee's Espresso Blend has quickly earned them a reputation in and around Cape Town. Full-bodied and well-developed, it makes great milk & espresso-based drinks which is why you'll find it in many restaurants and cafés in the Mother City!", "404.jpg", (byte)0, 45500, 22000, "Tribe Coffee - Espresso Blend", "SouthAfrica", "Dark", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9062) },
                    { 16, 9000, 7000, "Blend", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9059), "häzz coffee is a rich and subtle, truly modern blend of South American and African origin, suitable for any palate.  It offers an exceptionally wide range of aromas, accompanied by a bold but round and smooth body.In 2012, it won a Gold Medal at the annual International Coffee Tasting in Italy.", "404.jpg", (byte)0, 30000, 12500, "hazz blend - coffee for heroes", "South America and Africa", "light", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9060) },
                    { 15, 1600, 1550, "Catuai", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9057), "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", (byte)0, 60000, 16000, "Rosetta Roastery - Honduras San Franscisco Natural", "Marcala", "Dark", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9057) },
                    { 14, 1200, 1100, "Blend", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9055), "This blend was concocted early one morning when there just wasn't enough of one of the components, and a certain CCTeam member thought, 'what the heck ?'  And so, a blend was born, and it tasted like fruit salad in a cup. It kind of makes sense in the end if you think about it.", "404.jpg", (byte)0, 26000, 12500, "Fruit Salad Cape Coffee Blend", "South Afica", "Medium", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9056) },
                    { 13, 2000, 1700, "Red Bourbon", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9053), "Rwanda Musasa is a returning favourite from Origin Coffee Roasting. Highly celebrated, the Musasa Dukunde Kawa Cooperative is known all over the world for its top quality Red Bourbon beans.", "404.jpg", (byte)0, 28000, 8000, "Origin Coffee Roasting - Rwanda Musasa Ruli", "Ruli", "light", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9054) },
                    { 12, 9000, 7000, "Arabic", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9051), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9052) },
                    { 11, 1350, 1000, "Cauvery", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9049), "The coffee comes from the Allana estate in the former state of Mysore in India, now part of Karnataka. While the geographic area no longer bears the name, the coffees from that area are still referred to as Indian Mysore.", "404.jpg", (byte)0, 28000, 8000, "Truth. - India Single Origin", "India", "Medium", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9050) },
                    { 10, 9000, 7000, "BVurundi", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9047), "Bourbon type varietal.Cup profiles can be dynamic and bright, with red fruits, berry or citrus.Medium body and rounded mouth feel with a lingering finish.It’s no secret that Burundi has the potential to produce great coffee.", "404.jpg", (byte)0, 36000, 10000, "BURUNDI KIBIRA", "India", "light", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9048) },
                    { 9, 1600, 1420, "Catui", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9045), "While Central American coffee is generally well-respected, Honduras is definitely one of the lesser known producers in the region, at least here in South Africa. Equally many of the best Central American coffees are quite reserved in their flavour profiles.", "404.jpg", (byte)0, 32000, 18000, "Rosetta Roastery - Honduras San Franscisco Natural", "Honduras", "Dark", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9046) },
                    { 8, 1200, 1100, "Finca Idealista", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9043), "This is a spectacularly and deliciously unusual coffee. Its flavours are quite different from anything we've tasted before, and this may be in part due to the experimental processing method employed.", "404.jpg", (byte)0, 17000, 10000, "Quaffee - Nicaragua Finca Idealista Anaerobic Nanolot", "Nicaragua", "Medium", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9044) },
                    { 7, 1600, 1220, "Heirloom", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9042), "This Costa Rican single origin coffee from The Portland Project has everything that you might look for from that part of the coffee growing world. Its acidity is very discrete and body is full and satisfying.", "404.jpg", (byte)0, 29000, 10000, "Portland Project - Costa Rica Trojas", "Costa Rica", "Dark", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9042) },
                    { 6, 1700, 1675, "Primarily Caturra & Catuai", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9040), "Origin Coffee Roasting's decafs are surprisingly delicious. They select top quality single origin beans that are decaffeinated using a chemical-free process, to ensure maximum flavour retention and no unpleasant artificial qualities.", "404.jpg", (byte)0, 35000, 15000, "Origin Coffee Roasting - Guatemala Santa Sofia", "Guatamala", "light", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9040) },
                    { 5, 9000, 7000, "Arabic", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9038), "Villa Rosario is a colony in the Caranavi area of Yungus. The colony is located between 1550 and 1650 masl and is surrounded by jungle and small coffee farms.", "404.jpg", (byte)0, 16000, 8000, "Legado - Bolivia Villa Rosario Organic", "Bolivia", "Dark", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9038) },
                    { 4, 10000, 9500, "Blend", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9036), "Bean There's Blend 44 combines their very popular Ethiopia Sidamo, and one of our favourites, their Burundi Musema & Nyarurama. The marriage of these two wonderful coffees yields everything you might want in a bold yet balanced coffee, suitable for manual brewing or espresso.", "404.jpg", (byte)0, 25000, 6000, "Bean There - Blend 44", "Ethiopia", "Light", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9036) },
                    { 3, 1800, 1600, "Arabic", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9034), "Truth seems to have had a bit of a love affair with Burundian coffee in the last few years, one from which we have all benefited. They've had a streak of delicious examples of the up and coming coffee producing country's very best exports that we have thoroughly enjoyed.", "404.jpg", (byte)0, 32000, 10000, "Truth. - Burundi", "Burundi", "light", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9035) },
                    { 2, 2500, 2000, "Hierloom", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9022), "Guji is one of those regions of Ethiopia that have garnered much more attention in recent years, competing with the classically popular areas like Yirgacheffe & Limu.", "404.jpg", (byte)0, 31000, 9000, "Truth. - Ethiopia Guji", "Ethiopia", "Medium", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9026) },
                    { 1, 9000, 7000, "Arabic", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(2615), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(8451) },
                    { 20, 10000, 9000, "Catuai", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9067), "A filter grind perfect for plungers, pour overs and more. We've selected 5 varieties of coffee beans for our premium Alpha coffee blend. Rich fruited aromas with a hint of spice. Stoned fruit, nuts and apricot. Balanced citrus and acidity", "404.jpg", (byte)0, 30000, 12000, "Coffee Lab Alpha", "South Africa", "Dark", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9067) },
                    { 21, 5000, 3500, "Arabic", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9068), "Turkish Coffee ground to the finest Powder with a touch of elachi spice for that exotic flavour.", "404.jpg", (byte)0, 28000, 8000, "Titanium Coffee Turkish", "Turkish", "Dark", new DateTime(2019, 10, 18, 10, 9, 58, 603, DateTimeKind.Local).AddTicks(9069) }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "ProductID", "created_at", "isAvailable", "isDeleted", "price", "quantity", "tax_amount", "updated_at", "weight" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(1115), (byte)1, (byte)0, 8000, 15, 1200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(1359), 250 },
                    { 34, 12, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2208), (byte)1, (byte)0, 8000, 6, 1200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2209), 250 },
                    { 35, 12, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2210), (byte)1, (byte)0, 15000, 7, 2250, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2210), 500 },
                    { 36, 12, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2212), (byte)1, (byte)0, 28000, 8, 4200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2212), 1000 },
                    { 37, 13, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2213), (byte)1, (byte)0, 8000, 22, 1200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2214), 250 },
                    { 38, 13, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2215), (byte)1, (byte)0, 15000, 11, 2250, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2215), 500 },
                    { 39, 13, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2216), (byte)1, (byte)0, 28000, 44, 4200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2217), 1000 },
                    { 40, 14, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2218), (byte)1, (byte)0, 12500, 15, 1875, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2219), 250 },
                    { 41, 14, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2220), (byte)1, (byte)0, 18000, 16, 2700, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2220), 500 },
                    { 42, 14, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2221), (byte)1, (byte)0, 26000, 17, 3900, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2222), 1000 },
                    { 43, 15, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2272), (byte)1, (byte)0, 16000, 12, 2400, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2273), 250 },
                    { 44, 15, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2274), (byte)1, (byte)0, 32000, 22, 4800, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2275), 500 },
                    { 45, 15, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2276), (byte)1, (byte)0, 60000, 26, 9000, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2276), 1000 },
                    { 46, 16, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2277), (byte)1, (byte)0, 12500, 4, 1875, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2278), 250 },
                    { 33, 11, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2207), (byte)1, (byte)0, 28000, 33, 4200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2207), 1000 },
                    { 47, 16, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2279), (byte)1, (byte)0, 17000, 22, 2550, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2280), 500 },
                    { 49, 17, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2283), (byte)1, (byte)0, 22000, 21, 3300, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2283), 250 },
                    { 50, 17, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2284), (byte)1, (byte)0, 31000, 11, 4650, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2285), 500 },
                    { 51, 17, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2286), (byte)1, (byte)0, 45500, 11, 6825, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2286), 1000 },
                    { 52, 18, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2287), (byte)1, (byte)0, 15100, 22, 2265, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2288), 250 },
                    { 53, 18, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2289), (byte)1, (byte)0, 18000, 12, 2700, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2290), 500 },
                    { 54, 18, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2291), (byte)1, (byte)0, 21200, 32, 3180, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2291), 1000 },
                    { 55, 19, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2292), (byte)1, (byte)0, 32000, 21, 4800, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2293), 250 },
                    { 56, 19, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2294), (byte)1, (byte)0, 40000, 11, 6000, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2294), 500 },
                    { 57, 19, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2296), (byte)1, (byte)0, 50000, 15, 7500, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2296), 1000 },
                    { 58, 20, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2297), (byte)1, (byte)0, 12000, 44, 1800, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2298), 250 },
                    { 59, 20, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2299), (byte)1, (byte)0, 20000, 15, 3000, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2299), 500 },
                    { 60, 20, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2300), (byte)1, (byte)0, 30000, 21, 4500, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2301), 1000 },
                    { 61, 21, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2302), (byte)1, (byte)0, 8000, 11, 1200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2303), 250 },
                    { 48, 16, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2281), (byte)1, (byte)0, 30000, 9, 4500, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2281), 1000 },
                    { 62, 21, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2304), (byte)1, (byte)0, 16000, 1, 2400, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2304), 500 },
                    { 32, 11, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2205), (byte)1, (byte)0, 15000, 13, 2250, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2205), 500 },
                    { 30, 10, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2202), (byte)1, (byte)0, 36000, 11, 5400, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2202), 1000 },
                    { 2, 1, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2140), (byte)1, (byte)0, 15000, 15, 2250, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2144), 500 },
                    { 3, 1, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2157), (byte)1, (byte)0, 28000, 15, 4200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2158), 1000 },
                    { 4, 2, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2159), (byte)1, (byte)0, 9000, 10, 1350, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2159), 250 },
                    { 5, 2, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2161), (byte)1, (byte)0, 15000, 11, 2250, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2161), 500 },
                    { 6, 2, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2162), (byte)1, (byte)0, 31000, 12, 4650, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2163), 1000 },
                    { 7, 3, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2164), (byte)1, (byte)0, 10000, 13, 1500, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2165), 250 },
                    { 8, 3, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2166), (byte)1, (byte)0, 22000, 25, 3300, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2166), 500 },
                    { 9, 3, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2168), (byte)1, (byte)0, 32000, 5, 4800, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2168), 1000 },
                    { 10, 4, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2169), (byte)1, (byte)0, 6000, 13, 900, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2170), 250 },
                    { 11, 4, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2171), (byte)1, (byte)0, 14000, 35, 2100, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2171), 500 },
                    { 12, 4, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2172), (byte)1, (byte)0, 25000, 19, 3750, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2173), 1000 },
                    { 13, 5, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2174), (byte)1, (byte)0, 8000, 16, 1200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2174), 250 },
                    { 14, 5, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2175), (byte)1, (byte)0, 12000, 17, 1800, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2176), 500 },
                    { 31, 11, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2203), (byte)1, (byte)0, 8000, 7, 1200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2204), 250 },
                    { 15, 5, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2177), (byte)1, (byte)0, 16000, 11, 2400, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2178), 1000 },
                    { 17, 6, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2180), (byte)1, (byte)0, 20000, 25, 3000, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2181), 500 },
                    { 18, 6, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2182), (byte)1, (byte)0, 35000, 19, 5250, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2183), 1000 },
                    { 19, 7, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2184), (byte)1, (byte)0, 10000, 16, 1500, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2184), 250 },
                    { 20, 7, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2185), (byte)1, (byte)0, 19000, 15, 2850, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2186), 500 },
                    { 21, 7, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2187), (byte)1, (byte)0, 29000, 17, 4350, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2187), 1000 },
                    { 22, 8, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2189), (byte)1, (byte)0, 10000, 17, 1500, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2189), 250 },
                    { 23, 8, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2190), (byte)1, (byte)0, 13500, 13, 2025, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2191), 500 },
                    { 24, 8, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2192), (byte)1, (byte)0, 17000, 25, 2550, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2193), 1000 },
                    { 25, 9, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2194), (byte)1, (byte)0, 18000, 35, 2700, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2194), 250 },
                    { 26, 9, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2195), (byte)1, (byte)0, 26000, 11, 3900, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2196), 500 },
                    { 27, 9, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2197), (byte)1, (byte)0, 32000, 9, 4800, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2197), 1000 },
                    { 28, 10, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2199), (byte)1, (byte)0, 10000, 15, 1500, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2199), 250 },
                    { 29, 10, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2200), (byte)1, (byte)0, 19000, 21, 2850, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2201), 500 },
                    { 16, 6, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2179), (byte)1, (byte)0, 15000, 33, 2250, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2179), 250 },
                    { 63, 21, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2305), (byte)1, (byte)0, 28000, 2, 4200, new DateTime(2019, 10, 18, 10, 9, 58, 604, DateTimeKind.Local).AddTicks(2306), 1000 }
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
                name: "ProductOptions");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
