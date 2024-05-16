using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class UpdateCashbackTabMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CashbackTabs_CashbackContextId",
                table: "CashbackTabs",
                column: "CashbackContextId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CashbackTabs_CashbackContexts_CashbackContextId",
                table: "CashbackTabs",
                column: "CashbackContextId",
                principalTable: "CashbackContexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashbackTabs_CashbackContexts_CashbackContextId",
                table: "CashbackTabs");

            migrationBuilder.DropIndex(
                name: "IX_CashbackTabs_CashbackContextId",
                table: "CashbackTabs");
        }
    }
}
