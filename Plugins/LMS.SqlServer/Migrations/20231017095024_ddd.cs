using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2023, 10, 17, 11, 50, 24, 829, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2023, 10, 17, 11, 50, 24, 829, DateTimeKind.Local).AddTicks(863));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2023, 10, 16, 7, 28, 47, 695, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2023, 10, 16, 7, 28, 47, 695, DateTimeKind.Local).AddTicks(719));
        }
    }
}
