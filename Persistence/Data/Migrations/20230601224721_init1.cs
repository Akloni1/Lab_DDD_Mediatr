using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainDrivenDesign.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "character varying(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");
        }
    }
}
