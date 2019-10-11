using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 10, 21, 47, 28, 957, DateTimeKind.Local).AddTicks(9882), new DateTime(2019, 10, 10, 21, 47, 28, 958, DateTimeKind.Local).AddTicks(324) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 10, 21, 47, 28, 958, DateTimeKind.Local).AddTicks(1765), new DateTime(2019, 10, 10, 21, 47, 28, 958, DateTimeKind.Local).AddTicks(1774) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 10, 21, 47, 28, 958, DateTimeKind.Local).AddTicks(1789), new DateTime(2019, 10, 10, 21, 47, 28, 958, DateTimeKind.Local).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 10, 21, 47, 28, 956, DateTimeKind.Local).AddTicks(4280), new DateTime(2019, 10, 10, 21, 47, 28, 957, DateTimeKind.Local).AddTicks(3123) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 10, 20, 36, 54, 690, DateTimeKind.Local).AddTicks(9420), new DateTime(2019, 10, 10, 20, 36, 54, 690, DateTimeKind.Local).AddTicks(9680) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 10, 20, 36, 54, 691, DateTimeKind.Local).AddTicks(463), new DateTime(2019, 10, 10, 20, 36, 54, 691, DateTimeKind.Local).AddTicks(468) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 10, 20, 36, 54, 691, DateTimeKind.Local).AddTicks(480), new DateTime(2019, 10, 10, 20, 36, 54, 691, DateTimeKind.Local).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 10, 20, 36, 54, 689, DateTimeKind.Local).AddTicks(3979), new DateTime(2019, 10, 10, 20, 36, 54, 690, DateTimeKind.Local).AddTicks(2924) });
        }
    }
}
