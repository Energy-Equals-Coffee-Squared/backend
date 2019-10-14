using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class invoices_items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    ProductOptionID = table.Column<int>(type: "int", nullable: false),
                    prod_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_desc = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_region = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_roast = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_altitude_max = table.Column<int>(type: "int", nullable: false),
                    prod_altitude_min = table.Column<int>(type: "int", nullable: false),
                    prod_bean_type = table.Column<string>(type: "varchar(255)", nullable: false),
                    prod_image_url = table.Column<string>(type: "varchar(255)", nullable: false),
                    opt_price = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceID",
                table: "InvoiceItems",
                column: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 14, 13, 29, 58, 877, DateTimeKind.Local).AddTicks(9324), new DateTime(2019, 10, 14, 13, 29, 58, 877, DateTimeKind.Local).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 14, 13, 29, 58, 878, DateTimeKind.Local).AddTicks(1599), new DateTime(2019, 10, 14, 13, 29, 58, 878, DateTimeKind.Local).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 14, 13, 29, 58, 878, DateTimeKind.Local).AddTicks(1619), new DateTime(2019, 10, 14, 13, 29, 58, 878, DateTimeKind.Local).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 14, 13, 29, 58, 876, DateTimeKind.Local).AddTicks(7581), new DateTime(2019, 10, 14, 13, 29, 58, 877, DateTimeKind.Local).AddTicks(4250) });
        }
    }
}
