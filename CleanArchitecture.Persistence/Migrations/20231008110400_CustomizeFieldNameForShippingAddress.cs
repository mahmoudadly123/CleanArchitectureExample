using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomizeFieldNameForShippingAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Street",
                table: "Sales.Orders",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Region",
                table: "Sales.Orders",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Floor",
                table: "Sales.Orders",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Country",
                table: "Sales.Orders",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_City",
                table: "Sales.Orders",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Building",
                table: "Sales.Orders",
                newName: "Building");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Apartment",
                table: "Sales.Orders",
                newName: "Apartment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Sales.Orders",
                newName: "ShippingAddress_Street");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Sales.Orders",
                newName: "ShippingAddress_Region");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Sales.Orders",
                newName: "ShippingAddress_Floor");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Sales.Orders",
                newName: "ShippingAddress_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Sales.Orders",
                newName: "ShippingAddress_City");

            migrationBuilder.RenameColumn(
                name: "Building",
                table: "Sales.Orders",
                newName: "ShippingAddress_Building");

            migrationBuilder.RenameColumn(
                name: "Apartment",
                table: "Sales.Orders",
                newName: "ShippingAddress_Apartment");
        }
    }
}
