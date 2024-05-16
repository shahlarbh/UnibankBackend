using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class CorrectionHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Visibility",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visibility",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Visibility",
                table: "Darkmodes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Darkmodes");
        }
    }
}
