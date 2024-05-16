using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unibank.DAL.Migrations
{
    public partial class CreateAboutBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BriefInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LegalForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trademark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subsidiaries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BriefInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNuber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Web = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SWIFT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VOEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auditor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditorAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BriefInfos");

            migrationBuilder.DropTable(
                name: "ContactCordinates");

            migrationBuilder.DropTable(
                name: "Licenses");
        }
    }
}
