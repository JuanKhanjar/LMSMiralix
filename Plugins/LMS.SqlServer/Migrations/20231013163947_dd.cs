using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_PurchasedProducts_PurchasedProductId",
                table: "GroupProducts");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CustomerName", "Email", "PhoneNumber", "RegistrationDate" },
                values: new object[] { "Vejle Kommune", "vejle@gmail.com", "429292929", new DateTime(2023, 10, 13, 18, 39, 47, 71, DateTimeKind.Local).AddTicks(6392) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CustomerName", "Email", "PhoneNumber", "RegistrationDate" },
                values: new object[] { "Herning Kommune", "herning@gmail.com", "429292930", new DateTime(2023, 10, 13, 18, 39, 47, 71, DateTimeKind.Local).AddTicks(6438) });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_PurchasedProducts_PurchasedProductId",
                table: "GroupProducts",
                column: "PurchasedProductId",
                principalTable: "PurchasedProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_PurchasedProducts_PurchasedProductId",
                table: "GroupProducts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CustomerName",
                value: "John Doe");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CustomerName",
                value: "Jane Smith");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_PurchasedProducts_PurchasedProductId",
                table: "GroupProducts",
                column: "PurchasedProductId",
                principalTable: "PurchasedProducts",
                principalColumn: "ProductId");
        }
    }
}
