using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class UpdateTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferMethods_Methods_MethodsId",
                table: "TransferMethods");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "TransferMethods");

            migrationBuilder.RenameColumn(
                name: "MethodsId",
                table: "TransferMethods",
                newName: "MethodId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferMethods_MethodsId",
                table: "TransferMethods",
                newName: "IX_TransferMethods_MethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferMethods_Methods_MethodId",
                table: "TransferMethods",
                column: "MethodId",
                principalTable: "Methods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferMethods_Methods_MethodId",
                table: "TransferMethods");

            migrationBuilder.RenameColumn(
                name: "MethodId",
                table: "TransferMethods",
                newName: "MethodsId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferMethods_MethodId",
                table: "TransferMethods",
                newName: "IX_TransferMethods_MethodsId");

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "TransferMethods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferMethods_Methods_MethodsId",
                table: "TransferMethods",
                column: "MethodsId",
                principalTable: "Methods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
