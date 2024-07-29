using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTaxEntityWithSomeModifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales.OrdersItems_Sales.Orders_OrderId",
                table: "Sales.OrdersItems");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "Sales.OrdersItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sales.OrdersItems",
                newName: "OrderItemId");

            migrationBuilder.RenameColumn(
                name: "TaxValue",
                table: "Sales.OrdersItems",
                newName: "TaxesValue");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sales.Orders",
                newName: "OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Sales.OrdersItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sales.OrdersItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxesPercent",
                table: "Sales.OrdersItems",
                type: "decimal(18,5)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "OrderDescription",
                table: "Sales.Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Sales.OrdersItemsTaxes",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxPercent = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales.OrdersItemsTaxes", x => x.TaxId);
                    table.ForeignKey(
                        name: "FK_Sales.OrdersItemsTaxes_Sales.OrdersItems_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Sales.OrdersItems",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales.OrdersItemsTaxes_OrderId",
                table: "Sales.OrdersItemsTaxes",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales.OrdersItems_Sales.Orders_OrderId",
                table: "Sales.OrdersItems",
                column: "OrderId",
                principalTable: "Sales.Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales.OrdersItems_Sales.Orders_OrderId",
                table: "Sales.OrdersItems");

            migrationBuilder.DropTable(
                name: "Sales.OrdersItemsTaxes");

            migrationBuilder.DropColumn(
                name: "TaxesPercent",
                table: "Sales.OrdersItems");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "Sales.OrdersItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TaxesValue",
                table: "Sales.OrdersItems",
                newName: "TaxValue");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Sales.Orders",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Sales.OrdersItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sales.OrdersItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercent",
                table: "Sales.OrdersItems",
                type: "decimal(18,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "OrderDescription",
                table: "Sales.Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales.OrdersItems_Sales.Orders_OrderId",
                table: "Sales.OrdersItems",
                column: "OrderId",
                principalTable: "Sales.Orders",
                principalColumn: "Id");
        }
    }
}
