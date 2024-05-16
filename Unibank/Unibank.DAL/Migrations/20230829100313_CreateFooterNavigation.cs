using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class CreateFooterNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FooterNavigations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterNavigations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FooterNavigations_Footers_FooterId",
                        column: x => x.FooterId,
                        principalTable: "Footers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FooterNavigationExtentions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterNavigationId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterNavigationExtentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FooterNavigationExtentions_FooterNavigations_FooterNavigationId",
                        column: x => x.FooterNavigationId,
                        principalTable: "FooterNavigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FooterNavigationExtentions_FooterNavigationId",
                table: "FooterNavigationExtentions",
                column: "FooterNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_FooterNavigations_FooterId",
                table: "FooterNavigations",
                column: "FooterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterNavigationExtentions");

            migrationBuilder.DropTable(
                name: "FooterNavigations");
        }
    }
}
