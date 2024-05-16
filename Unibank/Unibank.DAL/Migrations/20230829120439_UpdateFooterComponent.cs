using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class UpdateFooterComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                table: "FooterNavigationExtentions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FooterNavigationExtentions_FooterId",
                table: "FooterNavigationExtentions",
                column: "FooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_FooterNavigationExtentions_Footers_FooterId",
                table: "FooterNavigationExtentions",
                column: "FooterId",
                principalTable: "Footers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FooterNavigationExtentions_Footers_FooterId",
                table: "FooterNavigationExtentions");

            migrationBuilder.DropIndex(
                name: "IX_FooterNavigationExtentions_FooterId",
                table: "FooterNavigationExtentions");

            migrationBuilder.DropColumn(
                name: "FooterId",
                table: "FooterNavigationExtentions");
        }
    }
}
