﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    desc = table.Column<string>(type: "varchar(255)", nullable: false),
                    region = table.Column<string>(type: "varchar(255)", nullable: false),
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
                    product_id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    isAvailable = table.Column<byte>(type: "tinyint", nullable: false),
                    isDeleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_ProductId",
                table: "ProductOptions",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}