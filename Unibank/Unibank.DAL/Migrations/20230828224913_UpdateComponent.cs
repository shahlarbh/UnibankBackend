using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class UpdateComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutPageBoxes_Footers_FooterId",
                table: "AboutPageBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CardTypes_Footers_FooterId",
                table: "CardTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Footers_FooterId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Footers_FooterId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_DigitalBankings_Footers_FooterId",
                table: "DigitalBankings");

            migrationBuilder.DropForeignKey(
                name: "FK_Methods_Footers_FooterId",
                table: "Methods");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Footers_FooterId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_FooterId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Methods_FooterId",
                table: "Methods");

            migrationBuilder.DropIndex(
                name: "IX_DigitalBankings_FooterId",
                table: "DigitalBankings");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_FooterId",
                table: "Deposits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_FooterId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_CardTypes_FooterId",
                table: "CardTypes");

            migrationBuilder.DropIndex(
                name: "IX_AboutPageBoxes_FooterId",
                table: "AboutPageBoxes");

            migrationBuilder.DropColumn(
                name: "FooterId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FooterId",
                table: "Methods");

            migrationBuilder.DropColumn(
                name: "FooterId",
                table: "DigitalBankings");

            migrationBuilder.DropColumn(
                name: "FooterId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "FooterId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "FooterId",
                table: "CardTypes");

            migrationBuilder.DropColumn(
                name: "FooterId",
                table: "AboutPageBoxes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                table: "Methods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                table: "DigitalBankings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                table: "Deposits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                table: "Credits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                table: "CardTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FooterId",
                table: "AboutPageBoxes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_FooterId",
                table: "Services",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_FooterId",
                table: "Methods",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalBankings_FooterId",
                table: "DigitalBankings",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_FooterId",
                table: "Deposits",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_FooterId",
                table: "Credits",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTypes_FooterId",
                table: "CardTypes",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutPageBoxes_FooterId",
                table: "AboutPageBoxes",
                column: "FooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutPageBoxes_Footers_FooterId",
                table: "AboutPageBoxes",
                column: "FooterId",
                principalTable: "Footers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardTypes_Footers_FooterId",
                table: "CardTypes",
                column: "FooterId",
                principalTable: "Footers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Footers_FooterId",
                table: "Credits",
                column: "FooterId",
                principalTable: "Footers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Footers_FooterId",
                table: "Deposits",
                column: "FooterId",
                principalTable: "Footers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalBankings_Footers_FooterId",
                table: "DigitalBankings",
                column: "FooterId",
                principalTable: "Footers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Methods_Footers_FooterId",
                table: "Methods",
                column: "FooterId",
                principalTable: "Footers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Footers_FooterId",
                table: "Services",
                column: "FooterId",
                principalTable: "Footers",
                principalColumn: "Id");
        }
    }
}
