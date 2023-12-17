using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class editReportlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_reportLogs_reportStatusId",
                table: "reportLogs",
                column: "reportStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_reportLogs_reportStatuses_reportStatusId",
                table: "reportLogs",
                column: "reportStatusId",
                principalTable: "reportStatuses",
                principalColumn: "reportStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reportLogs_reportStatuses_reportStatusId",
                table: "reportLogs");

            migrationBuilder.DropIndex(
                name: "IX_reportLogs_reportStatusId",
                table: "reportLogs");
        }
    }
}
