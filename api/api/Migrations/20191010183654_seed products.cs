using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class seedproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "altitude_max", "altitude_min", "bean_type", "created_at", "desc", "image_url", "isDeleted", "max_price", "min_price", "name", "region", "roast", "updated_at" },
                values: new object[] { 1, 9000, 7000, "Arabic", new DateTime(2019, 10, 10, 20, 36, 54, 689, DateTimeKind.Local).AddTicks(3979), "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.", "404.jpg", (byte)0, 28000, 8000, "ETHIOPIAN LIMU", "Ethiopia", "light", new DateTime(2019, 10, 10, 20, 36, 54, 690, DateTimeKind.Local).AddTicks(2924) });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "ProductID", "created_at", "isAvailable", "isDeleted", "price", "quantity", "updated_at", "weight" },
                values: new object[] { 1, 1, new DateTime(2019, 10, 10, 20, 36, 54, 690, DateTimeKind.Local).AddTicks(9420), (byte)1, (byte)0, 8000, 15, new DateTime(2019, 10, 10, 20, 36, 54, 690, DateTimeKind.Local).AddTicks(9680), 250 });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "ProductID", "created_at", "isAvailable", "isDeleted", "price", "quantity", "updated_at", "weight" },
                values: new object[] { 2, 1, new DateTime(2019, 10, 10, 20, 36, 54, 691, DateTimeKind.Local).AddTicks(463), (byte)1, (byte)0, 15000, 15, new DateTime(2019, 10, 10, 20, 36, 54, 691, DateTimeKind.Local).AddTicks(468), 500 });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "ProductID", "created_at", "isAvailable", "isDeleted", "price", "quantity", "updated_at", "weight" },
                values: new object[] { 3, 1, new DateTime(2019, 10, 10, 20, 36, 54, 691, DateTimeKind.Local).AddTicks(480), (byte)1, (byte)0, 28000, 15, new DateTime(2019, 10, 10, 20, 36, 54, 691, DateTimeKind.Local).AddTicks(481), 1000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
