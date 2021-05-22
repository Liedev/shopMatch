using Microsoft.EntityFrameworkCore.Migrations;

namespace Winkellijst_ASP.Migrations
{
    public partial class WinkellijstNaam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                schema: "Winkellijst",
                table: "WinkelLijstProduct");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                schema: "Winkellijst",
                table: "Boodschappenlijst",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                schema: "Winkellijst",
                table: "Boodschappenlijst");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                schema: "Winkellijst",
                table: "WinkelLijstProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
