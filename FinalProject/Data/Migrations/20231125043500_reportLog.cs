using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class reportLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reportLogs",
                columns: table => new
                {
                    reportLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reportId = table.Column<int>(type: "int", nullable: false),
                    reportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reportDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reportNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reportStatusId = table.Column<int>(type: "int", nullable: false),
                    reportDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportLogs", x => x.reportLogId);
                    table.ForeignKey(
                        name: "FK_reportLogs_reports_reportId",
                        column: x => x.reportId,
                        principalTable: "reports",
                        principalColumn: "reportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reportLogs_reportId",
                table: "reportLogs",
                column: "reportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reportLogs");
        }
    }
}
