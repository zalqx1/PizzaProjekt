using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaProjekt.Migrations
{
    public partial class AddMMTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsOrders");

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersPizza",
                columns: table => new
                {
                    OrdersId = table.Column<int>(nullable: false),
                    PizzaId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersPizza", x => new { x.OrdersId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_OrdersPizza_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersPizza_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredients",
                columns: table => new
                {
                    PizzaId = table.Column<int>(nullable: false),
                    IngredientsId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredients", x => new { x.PizzaId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_PizzaIngredients_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngredients_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersPizza_PizzaId",
                table: "OrdersPizza",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredients_IngredientsId",
                table: "PizzaIngredients",
                column: "IngredientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersPizza");

            migrationBuilder.DropTable(
                name: "PizzaIngredients");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.CreateTable(
                name: "IngredientsOrders",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsOrders_OrdersId",
                table: "IngredientsOrders",
                column: "OrdersId");
        }
    }
}
