using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Library.Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Library.Books",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Library.Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Library.Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Sales.Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Building = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Apartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales.Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales.OrdersItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    AdditionsValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    AdditionsPercent = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales.OrdersItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales.OrdersItems_Sales.Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Sales.Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Library.Books",
                columns: new[] { "Id", "Category", "CreatedBy", "CreatedDate", "Description", "IsActive", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { -6, "DataAccess", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lean EntityFrameworkCore", false, "EntityFrameworkCore", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -5, "Desktop", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lean DevExpress For Desktop Apps", false, "DevExpress", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -4, "Mobile", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lean Flutter Programming", true, "Flutter", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -3, "Mobile", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lean Android Programming", true, "Android", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2, "Programming", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lean Rust Programming", true, "Rust", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1, "Programming", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lean OOP inside C#", true, "OOP C#", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales.OrdersItems_OrderId",
                table: "Sales.OrdersItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales.OrdersItems");

            migrationBuilder.DropTable(
                name: "Sales.Orders");

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Library.Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Library.Books",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Library.Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Library.Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Library.Books",
                columns: new[] { "Id", "Category", "CreatedBy", "CreatedDate", "Description", "IsActive", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Programming", 1, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5319), "Lean OOP inside C#", true, "OOP C#", 0, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5374) },
                    { 2, "Programming", 1, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5381), "Lean Rust Programming", true, "Rust", 0, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5383) },
                    { 3, "Mobile", 1, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5386), "Lean Android Programming", true, "Android", 0, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5389) },
                    { 4, "Mobile", 1, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5392), "Lean Flutter Programming", true, "Flutter", 0, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5394) },
                    { 5, "Desktop", 1, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5397), "Lean DevExpress For Desktop Apps", false, "DevExpress", 0, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5399) },
                    { 6, "DataAccess", 1, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5406), "Lean EntityFrameworkCore", false, "EntityFrameworkCore", 0, new DateTime(2023, 9, 25, 14, 30, 31, 512, DateTimeKind.Local).AddTicks(5408) }
                });
        }
    }
}
