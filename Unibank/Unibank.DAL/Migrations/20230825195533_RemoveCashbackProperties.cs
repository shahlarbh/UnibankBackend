using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class RemoveCashbackProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContextVisibility",
                table: "CashbackInfoBoxes");

            migrationBuilder.DropColumn(
                name: "TabDesign",
                table: "CashbackInfoBoxes");

            migrationBuilder.DropColumn(
                name: "TabVisibility",
                table: "CashbackInfoBoxes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContextVisibility",
                table: "CashbackInfoBoxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TabDesign",
                table: "CashbackInfoBoxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TabVisibility",
                table: "CashbackInfoBoxes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
