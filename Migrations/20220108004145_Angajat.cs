using Microsoft.EntityFrameworkCore.Migrations;

namespace Istrate_Alexandra_Proiect.Migrations
{
    public partial class Angajat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AngajatID",
                table: "Apartament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumePrenumeAngajat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartament_AngajatID",
                table: "Apartament",
                column: "AngajatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartament_Angajat_AngajatID",
                table: "Apartament",
                column: "AngajatID",
                principalTable: "Angajat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartament_Angajat_AngajatID",
                table: "Apartament");

            migrationBuilder.DropTable(
                name: "Angajat");

            migrationBuilder.DropIndex(
                name: "IX_Apartament_AngajatID",
                table: "Apartament");

            migrationBuilder.DropColumn(
                name: "AngajatID",
                table: "Apartament");
        }
    }
}
