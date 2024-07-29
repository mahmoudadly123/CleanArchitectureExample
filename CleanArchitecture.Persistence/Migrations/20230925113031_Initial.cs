using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Library.Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library.Books", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Library.Books");
        }
    }
}
