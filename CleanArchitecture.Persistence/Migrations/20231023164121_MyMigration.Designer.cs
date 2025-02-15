﻿// <auto-generated />
using System;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231023164121_MyMigration")]
    partial class MyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitecture.Domain.Aggregates.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sales.Orders", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Library.Books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Category = "Programming",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8165),
                            Description = "Lean OOP inside C#",
                            IsActive = true,
                            Title = "OOP C#",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8227)
                        },
                        new
                        {
                            Id = -2,
                            Category = "Programming",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8315),
                            Description = "Lean Rust Programming",
                            IsActive = true,
                            Title = "Rust",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8319)
                        },
                        new
                        {
                            Id = -3,
                            Category = "Mobile",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8328),
                            Description = "Lean Android Programming",
                            IsActive = true,
                            Title = "Android",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8330)
                        },
                        new
                        {
                            Id = -4,
                            Category = "Mobile",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8337),
                            Description = "Lean Flutter Programming",
                            IsActive = true,
                            Title = "Flutter",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8339)
                        },
                        new
                        {
                            Id = -5,
                            Category = "Desktop",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8345),
                            Description = "Lean DevExpress For Desktop Apps",
                            IsActive = false,
                            Title = "DevExpress",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8347)
                        },
                        new
                        {
                            Id = -6,
                            Category = "DataAccess",
                            CreatedBy = 0,
                            CreatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8357),
                            Description = "Lean EntityFrameworkCore",
                            IsActive = false,
                            Title = "EntityFrameworkCore",
                            UpdatedBy = 0,
                            UpdatedDate = new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8359)
                        });
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Aggregates.Order", b =>
                {
                    b.OwnsMany("CleanArchitecture.Domain.Entities.OrderItem", "OrderItems", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasColumnName("OrderItemId");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<decimal>("AdditionsPercent")
                                .HasColumnType("decimal(18,3)");

                            b1.Property<decimal>("AdditionsValue")
                                .HasColumnType("decimal(18,3)");

                            b1.Property<int>("CreatedBy")
                                .HasColumnType("int");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<decimal>("DiscountPercent")
                                .HasColumnType("decimal(18,3)");

                            b1.Property<decimal>("DiscountValue")
                                .HasColumnType("decimal(18,3)");

                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Quantity")
                                .HasColumnType("decimal(18,3)");

                            b1.Property<decimal>("TaxesPercent")
                                .HasColumnType("decimal(18,5)");

                            b1.Property<decimal>("TaxesValue")
                                .HasColumnType("decimal(18,3)");

                            b1.Property<decimal>("UnitPrice")
                                .HasColumnType("decimal(18,3)");

                            b1.Property<int>("UpdatedBy")
                                .HasColumnType("int");

                            b1.Property<DateTime>("UpdatedDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId");

                            b1.ToTable("Sales.OrdersItems", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("OrderId");

                            b1.OwnsMany("CleanArchitecture.Domain.Entities.Tax", "ItemTaxes", b2 =>
                                {
                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasColumnName("TaxId");

                                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b2.Property<int>("Id"));

                                    b2.Property<int>("CreatedBy")
                                        .HasColumnType("int");

                                    b2.Property<DateTime>("CreatedDate")
                                        .HasColumnType("datetime2");

                                    b2.Property<bool>("IsActive")
                                        .HasColumnType("bit");

                                    b2.Property<int>("OrderId")
                                        .HasColumnType("int");

                                    b2.Property<int>("OrderItemId")
                                        .HasColumnType("int");

                                    b2.Property<string>("TaxName")
                                        .IsRequired()
                                        .HasMaxLength(200)
                                        .HasColumnType("nvarchar(200)");

                                    b2.Property<decimal>("TaxPercent")
                                        .HasColumnType("decimal(18,5)");

                                    b2.Property<decimal>("TaxValue")
                                        .HasColumnType("decimal(18,3)");

                                    b2.Property<int>("UpdatedBy")
                                        .HasColumnType("int");

                                    b2.Property<DateTime>("UpdatedDate")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("Id");

                                    b2.HasIndex("OrderId");

                                    b2.ToTable("Sales.OrdersItemsTaxes", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("OrderId");
                                });

                            b1.Navigation("ItemTaxes");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.ValueObjects.ShippingAddress", "ShippingAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("Apartment")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Apartment");

                            b1.Property<string>("Building")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Building");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("Floor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Floor");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Region");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.HasKey("OrderId");

                            b1.ToTable("Sales.Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("OrderItems");

                    b.Navigation("ShippingAddress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
