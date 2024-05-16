using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class CreateCashbackInfoBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashbackTabs");

            migrationBuilder.DropTable(
                name: "CashbackContexts");

            migrationBuilder.CreateTable(
                name: "CashbackInfoBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TabTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TabVisibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TabDesign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContextVisibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashbackInfoBoxes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashbackInfoBoxes");

            migrationBuilder.CreateTable(
                name: "CashbackContexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaskbackTabId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashbackContexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashbackTabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashbackContextId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashbackTabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashbackTabs_CashbackContexts_CashbackContextId",
                        column: x => x.CashbackContextId,
                        principalTable: "CashbackContexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashbackTabs_CashbackContextId",
                table: "CashbackTabs",
                column: "CashbackContextId",
                unique: true);
        }
    }
}
