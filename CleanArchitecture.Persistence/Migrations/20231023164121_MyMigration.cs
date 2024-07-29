using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8357), new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8345), new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8337), new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8328), new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8315), new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8319) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8165), new DateTime(2023, 10, 23, 19, 41, 20, 802, DateTimeKind.Local).AddTicks(8227) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Library.Books",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
