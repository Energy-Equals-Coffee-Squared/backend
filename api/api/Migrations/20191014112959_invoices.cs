using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class invoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserID",
                table: "Invoices",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

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
    }
}
