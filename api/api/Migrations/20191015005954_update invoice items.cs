using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class updateinvoiceitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "opt_weight",
                table: "InvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 15, 2, 59, 54, 783, DateTimeKind.Local).AddTicks(682), new DateTime(2019, 10, 15, 2, 59, 54, 783, DateTimeKind.Local).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 15, 2, 59, 54, 783, DateTimeKind.Local).AddTicks(1882), new DateTime(2019, 10, 15, 2, 59, 54, 783, DateTimeKind.Local).AddTicks(1887) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 15, 2, 59, 54, 783, DateTimeKind.Local).AddTicks(1900), new DateTime(2019, 10, 15, 2, 59, 54, 783, DateTimeKind.Local).AddTicks(1900) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 15, 2, 59, 54, 782, DateTimeKind.Local).AddTicks(1676), new DateTime(2019, 10, 15, 2, 59, 54, 782, DateTimeKind.Local).AddTicks(6839) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "opt_weight",
                table: "InvoiceItems");

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 14, 13, 30, 38, 990, DateTimeKind.Local).AddTicks(8675), new DateTime(2019, 10, 14, 13, 30, 38, 990, DateTimeKind.Local).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 14, 13, 30, 38, 991, DateTimeKind.Local).AddTicks(717), new DateTime(2019, 10, 14, 13, 30, 38, 991, DateTimeKind.Local).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 14, 13, 30, 38, 991, DateTimeKind.Local).AddTicks(735), new DateTime(2019, 10, 14, 13, 30, 38, 991, DateTimeKind.Local).AddTicks(736) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 14, 13, 30, 38, 989, DateTimeKind.Local).AddTicks(8010), new DateTime(2019, 10, 14, 13, 30, 38, 990, DateTimeKind.Local).AddTicks(4085) });
        }
    }
}
