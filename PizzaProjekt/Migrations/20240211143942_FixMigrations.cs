using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaProjekt.Migrations
{
    public partial class FixMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    gruppe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    street = table.Column<string>(nullable: true),
                    number = table.Column<int>(nullable: false),
                    postCode = table.Column<int>(nullable: false),
                    city = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    nachname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsOrders",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(nullable: false),
                    OrdersId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsOrders", x => new { x.IngredientsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_IngredientsOrders_Ingredients_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsOrders_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsOrders_OrdersId",
                table: "IngredientsOrders",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsOrders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
