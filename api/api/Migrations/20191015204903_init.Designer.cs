﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Models;

namespace api.Migrations
{
    [DbContext(typeof(CoffeeContext))]
    [Migration("20191015204903_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.Models.DiscountCodes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("percentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DiscountCodes");
                });

            modelBuilder.Entity("api.Models.InvoiceItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceID")
                        .HasColumnType("int");

                    b.Property<int>("ProductOptionID")
                        .HasColumnType("int");

                    b.Property<int>("opt_price")
                        .HasColumnType("int");

                    b.Property<int>("opt_weight")
                        .HasColumnType("int");

                    b.Property<int>("prod_altitude_max")
                        .HasColumnType("int");

                    b.Property<int>("prod_altitude_min")
                        .HasColumnType("int");

                    b.Property<string>("prod_bean_type")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("prod_desc")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("prod_image_url")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("prod_name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("prod_region")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("prod_roast")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceID");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("api.Models.Invoices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("discount_code")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("discount_percentage")
                        .HasColumnType("int");

                    b.Property<byte>("isFreeShipping")
                        .HasColumnType("tinyint");

                    b.Property<int>("tax")
                        .HasColumnType("int");

                    b.Property<int>("total")
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("api.Models.ProductOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime");

                    b.Property<byte>("isAvailable")
                        .HasColumnType("tinyint");

                    b.Property<byte>("isDeleted")
                        .HasColumnType("tinyint");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductOptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductID = 1,
                            created_at = new DateTime(2019, 10, 15, 22, 49, 2, 758, DateTimeKind.Local).AddTicks(5317),
                            isAvailable = (byte)1,
                            isDeleted = (byte)0,
                            price = 8000,
                            quantity = 15,
                            updated_at = new DateTime(2019, 10, 15, 22, 49, 2, 758, DateTimeKind.Local).AddTicks(5797),
                            weight = 250
                        },
                        new
                        {
                            Id = 2,
                            ProductID = 1,
                            created_at = new DateTime(2019, 10, 15, 22, 49, 2, 758, DateTimeKind.Local).AddTicks(9235),
                            isAvailable = (byte)1,
                            isDeleted = (byte)0,
                            price = 15000,
                            quantity = 15,
                            updated_at = new DateTime(2019, 10, 15, 22, 49, 2, 758, DateTimeKind.Local).AddTicks(9246),
                            weight = 500
                        },
                        new
                        {
                            Id = 3,
                            ProductID = 1,
                            created_at = new DateTime(2019, 10, 15, 22, 49, 2, 758, DateTimeKind.Local).AddTicks(9260),
                            isAvailable = (byte)1,
                            isDeleted = (byte)0,
                            price = 28000,
                            quantity = 15,
                            updated_at = new DateTime(2019, 10, 15, 22, 49, 2, 758, DateTimeKind.Local).AddTicks(9261),
                            weight = 1000
                        });
                });

            modelBuilder.Entity("api.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("altitude_max")
                        .HasColumnType("int");

                    b.Property<int>("altitude_min")
                        .HasColumnType("int");

                    b.Property<string>("bean_type")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("image_url")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<byte>("isDeleted")
                        .HasColumnType("tinyint");

                    b.Property<int>("max_price")
                        .HasColumnType("int");

                    b.Property<int>("min_price")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("region")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("roast")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            altitude_max = 9000,
                            altitude_min = 7000,
                            bean_type = "Arabic",
                            created_at = new DateTime(2019, 10, 15, 22, 49, 2, 756, DateTimeKind.Local).AddTicks(7997),
                            desc = "Ethiopian Limu is from the western escarpments of the Ethiopian highlands. Our single origin is a fully washed, high quality coffee with rich, round flavour and a pronounced sweetness on the palate.",
                            image_url = "404.jpg",
                            isDeleted = (byte)0,
                            max_price = 28000,
                            min_price = 8000,
                            name = "ETHIOPIAN LIMU",
                            region = "Ethiopia",
                            roast = "light",
                            updated_at = new DateTime(2019, 10, 15, 22, 49, 2, 757, DateTimeKind.Local).AddTicks(4599)
                        });
                });

            modelBuilder.Entity("api.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contact_number")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<byte>("isActive")
                        .HasColumnType("tinyint");

                    b.Property<byte>("isAdmin")
                        .HasColumnType("tinyint");

                    b.Property<byte>("isDelted")
                        .HasColumnType("tinyint");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Models.InvoiceItems", b =>
                {
                    b.HasOne("api.Models.Invoices", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api.Models.Invoices", b =>
                {
                    b.HasOne("api.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api.Models.ProductOptions", b =>
                {
                    b.HasOne("api.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}