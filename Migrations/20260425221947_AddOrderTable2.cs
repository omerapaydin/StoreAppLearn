using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreAppLearn.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Products_productId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "OrderItem",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_productId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Products_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Products_ProductId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItem",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                newName: "IX_OrderItem_productId");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "OrderItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Products_productId",
                table: "OrderItem",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
