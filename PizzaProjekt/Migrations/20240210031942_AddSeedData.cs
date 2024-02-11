using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaProjekt.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "id", "gruppe", "name" },
                values: new object[,]
                {
                    { 1, "Meats", "Salami" },
                    { 2, "Meats", "Sucuk" },
                    { 3, "Meats", "Schinken" },
                    { 4, "Vegetables", "Pepperoni" },
                    { 5, "Vegetables", "Tomaten" },
                    { 6, "Vegetables", "Oliven" },
                    { 7, "Cheese", "Mozzarella" },
                    { 8, "Cheese", "Schafskäse" },
                    { 9, "Cheese", "Parmesan" }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Pizza Napoli" },
                    { 2, "Pizza Roma" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
