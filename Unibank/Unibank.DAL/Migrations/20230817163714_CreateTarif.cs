using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class CreateTarif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarifs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarifTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdfSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BroadcastDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifs");
        }
    }
}
