using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class updateAttshFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachAssignments");

            migrationBuilder.DropTable(
                name: "attachfileReports");

            migrationBuilder.AddColumn<int>(
                name: "assignmentId",
                table: "Attachfiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "reportId",
                table: "Attachfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachfiles_assignmentId",
                table: "Attachfiles",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachfiles_reportId",
                table: "Attachfiles",
                column: "reportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachfiles_assignments_assignmentId",
                table: "Attachfiles",
                column: "assignmentId",
                principalTable: "assignments",
                principalColumn: "assignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachfiles_reports_reportId",
                table: "Attachfiles",
                column: "reportId",
                principalTable: "reports",
                principalColumn: "reportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachfiles_assignments_assignmentId",
                table: "Attachfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachfiles_reports_reportId",
                table: "Attachfiles");

            migrationBuilder.DropIndex(
                name: "IX_Attachfiles_assignmentId",
                table: "Attachfiles");

            migrationBuilder.DropIndex(
                name: "IX_Attachfiles_reportId",
                table: "Attachfiles");

            migrationBuilder.DropColumn(
                name: "assignmentId",
                table: "Attachfiles");

            migrationBuilder.DropColumn(
                name: "reportId",
                table: "Attachfiles");

            migrationBuilder.CreateTable(
                name: "attachAssignments",
                columns: table => new
                {
                    attachfileId = table.Column<int>(type: "int", nullable: false),
                    assignmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachAssignments", x => new { x.attachfileId, x.assignmentId });
                    table.ForeignKey(
                        name: "FK_attachAssignments_assignments_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "assignments",
                        principalColumn: "assignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attachAssignments_Attachfiles_attachfileId",
                        column: x => x.attachfileId,
                        principalTable: "Attachfiles",
                        principalColumn: "attachfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attachfileReports",
                columns: table => new
                {
                    attachfileId = table.Column<int>(type: "int", nullable: false),
                    reportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachfileReports", x => new { x.attachfileId, x.reportId });
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
                name: "IX_attachAssignments_assignmentId",
                table: "attachAssignments",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_attachfileReports_reportId",
                table: "attachfileReports",
                column: "reportId");
        }
    }
}
