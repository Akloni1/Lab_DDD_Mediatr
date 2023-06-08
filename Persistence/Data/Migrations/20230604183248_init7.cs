using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDrivenDesign.Data.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Dishes_DishId",
                table: "Ingredient");

            migrationBuilder.AlterColumn<long>(
                name: "DishId",
                table: "Ingredient",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Dish",
                table: "Ingredient",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Dish",
                table: "Ingredient");

            migrationBuilder.AlterColumn<long>(
                name: "DishId",
                table: "Ingredient",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Dishes_DishId",
                table: "Ingredient",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");
        }
    }
}
