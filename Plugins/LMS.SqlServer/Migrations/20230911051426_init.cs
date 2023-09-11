using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_Groups_GroupId",
                table: "GroupProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_PurchasedProducts_PurchasedProductId",
                table: "GroupProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_Groups_GroupId",
                table: "GroupProducts",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_PurchasedProducts_PurchasedProductId",
                table: "GroupProducts",
                column: "PurchasedProductId",
                principalTable: "PurchasedProducts",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_Groups_GroupId",
                table: "GroupProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_PurchasedProducts_PurchasedProductId",
                table: "GroupProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_Groups_GroupId",
                table: "GroupProducts",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_PurchasedProducts_PurchasedProductId",
                table: "GroupProducts",
                column: "PurchasedProductId",
                principalTable: "PurchasedProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
