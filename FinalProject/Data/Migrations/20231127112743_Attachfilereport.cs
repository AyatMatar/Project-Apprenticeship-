using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class Attachfilereport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Attachfiles",
                newName: "attachfileId");

            migrationBuilder.CreateTable(
                name: "attachfileReports",
                columns: table => new
                {
                    rportId = table.Column<int>(type: "int", nullable: false),
                    attachfileId = table.Column<int>(type: "int", nullable: false),
                    reportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachfileReports", x => new { x.attachfileId, x.rportId });
                    table.ForeignKey(
                        name: "FK_attachfileReports_Attachfiles_attachfileId",
                        column: x => x.attachfileId,
                        principalTable: "Attachfiles",
                        principalColumn: "attachfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attachfileReports_reports_reportId",
                        column: x => x.reportId,
                        principalTable: "reports",
                        principalColumn: "reportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attachfileReports_reportId",
                table: "attachfileReports",
                column: "reportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachfileReports");

            migrationBuilder.RenameColumn(
                name: "attachfileId",
                table: "Attachfiles",
                newName: "id");
        }
    }
}
