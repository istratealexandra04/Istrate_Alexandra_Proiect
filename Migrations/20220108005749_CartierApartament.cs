using Microsoft.EntityFrameworkCore.Migrations;

namespace Istrate_Alexandra_Proiect.Migrations
{
    public partial class CartierApartament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCartier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartierApartament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartamentID = table.Column<int>(type: "int", nullable: false),
                    CartierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartierApartament", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartierApartament_Apartament_ApartamentID",
                        column: x => x.ApartamentID,
                        principalTable: "Apartament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartierApartament_Cartier_CartierID",
                        column: x => x.CartierID,
                        principalTable: "Cartier",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartierApartament_ApartamentID",
                table: "CartierApartament",
                column: "ApartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_CartierApartament_CartierID",
                table: "CartierApartament",
                column: "CartierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartierApartament");

            migrationBuilder.DropTable(
                name: "Cartier");
        }
    }
}
