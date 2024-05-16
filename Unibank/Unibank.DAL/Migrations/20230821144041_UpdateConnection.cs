using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class UpdateConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imgage",
                table: "ConnectionBanners",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ConnectionBanners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ConnectionBanners");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ConnectionBanners",
                newName: "Imgage");
        }
    }
}
