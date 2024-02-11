using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaProjekt.Migrations
{
    public partial class AddGroupToIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gruppe",
                table: "Ingredients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gruppe",
                table: "Ingredients");
        }
    }
}
