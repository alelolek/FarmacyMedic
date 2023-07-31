using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmacyMedic.Migrations
{
    /// <inheritdoc />
    public partial class productDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Orders_OrderId",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Orders_OrderId",
                table: "ProductDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Orders_OrderId",
                table: "ProductDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ProductDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Orders_OrderId",
                table: "ProductDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
