using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Emailsfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2023, 10, 13, 18, 39, 47, 71, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2023, 10, 13, 18, 39, 47, 71, DateTimeKind.Local).AddTicks(6438));
        }
    }
}
