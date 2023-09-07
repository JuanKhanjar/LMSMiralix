using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_Products_ProductId",
                table: "GroupProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "GroupProducts",
                newName: "PurchasedProductId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupProducts_ProductId",
                table: "GroupProducts",
                newName: "IX_GroupProducts_PurchasedProductId");

            migrationBuilder.CreateTable(
                name: "PurchasedProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasedQty = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedProducts", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_PurchasedProducts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedProducts_CustomerId",
                table: "PurchasedProducts",
                column: "CustomerId");

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

            migrationBuilder.DropTable(
                name: "PurchasedProducts");

            migrationBuilder.RenameColumn(
                name: "PurchasedProductId",
                table: "GroupProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupProducts_PurchasedProductId",
                table: "GroupProducts",
                newName: "IX_GroupProducts_ProductId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasedQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_Products_ProductId",
                table: "GroupProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
