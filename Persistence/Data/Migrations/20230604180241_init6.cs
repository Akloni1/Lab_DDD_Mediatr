using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDrivenDesign.Data.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DishId",
                table: "OrderItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_DishId",
                table: "OrderItem",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Dish",
                table: "OrderItem",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Dish",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_DishId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "OrderItem");
        }
    }
}
