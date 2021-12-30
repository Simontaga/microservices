using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreakyFashionServices.OrderService.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderlineDto");

            migrationBuilder.CreateTable(
                name: "Orderline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orderline_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_orderId",
                table: "Orderline",
                column: "orderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orderline");

            migrationBuilder.CreateTable(
                name: "OrderlineDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderlineDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderlineDto_Orders_orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "orderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderlineDto_orderId",
                table: "OrderlineDto",
                column: "orderId");
        }
    }
}
