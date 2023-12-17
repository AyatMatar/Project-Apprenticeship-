using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class migrationReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignments_reportStatuses_reportStatusId",
                table: "assignments");

            migrationBuilder.DropIndex(
                name: "IX_assignments_reportStatusId",
                table: "assignments");

            migrationBuilder.DropColumn(
                name: "reportStatusId",
                table: "assignments");

            migrationBuilder.AddColumn<int>(
                name: "assignmentId",
                table: "reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reportStatusId",
                table: "reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reports_assignmentId",
                table: "reports",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_reportStatusId",
                table: "reports",
                column: "reportStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_reports_assignments_assignmentId",
                table: "reports",
                column: "assignmentId",
                principalTable: "assignments",
                principalColumn: "assignmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_reportStatuses_reportStatusId",
                table: "reports",
                column: "reportStatusId",
                principalTable: "reportStatuses",
                principalColumn: "reportStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reports_assignments_assignmentId",
                table: "reports");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_reportStatuses_reportStatusId",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_reports_assignmentId",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_reports_reportStatusId",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "assignmentId",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "reportStatusId",
                table: "reports");

            migrationBuilder.AddColumn<int>(
                name: "reportStatusId",
                table: "assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_assignments_reportStatusId",
                table: "assignments",
                column: "reportStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_reportStatuses_reportStatusId",
                table: "assignments",
                column: "reportStatusId",
                principalTable: "reportStatuses",
                principalColumn: "reportStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
