using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class Attachfilereport2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reportId",
                table: "Attachfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachfiles_reportId",
                table: "Attachfiles",
                column: "reportId");

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
                name: "FK_Attachfiles_reports_reportId",
                table: "Attachfiles");

            migrationBuilder.DropIndex(
                name: "IX_Attachfiles_reportId",
                table: "Attachfiles");

            migrationBuilder.DropColumn(
                name: "reportId",
                table: "Attachfiles");
        }
    }
}
