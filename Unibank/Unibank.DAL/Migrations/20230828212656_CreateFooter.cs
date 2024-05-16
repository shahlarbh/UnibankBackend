using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class CreateFooter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FooterIcons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterIcons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FooterIcons_Footers_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FooterLeftEnds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterLeftEnds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FooterLeftEnds_Footers_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FooterRightEnds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterRightEnds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FooterRightEnds_Footers_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_FooterIcons_FooterId",
                table: "FooterIcons",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_FooterLeftEnds_FooterId",
                table: "FooterLeftEnds",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_FooterRightEnds_FooterId",
                table: "FooterRightEnds",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "FooterIcons");

            migrationBuilder.DropTable(
                name: "FooterLeftEnds");

            migrationBuilder.DropTable(
                name: "FooterRightEnds");

            migrationBuilder.DropTable(
                name: "Footers");

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
    }
}
