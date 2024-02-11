using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaProjekt.Migrations
{
    public partial class CreateManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsOrders_OrdersId",
                table: "IngredientsOrders",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsOrders");
        }
    }
}
