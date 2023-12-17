using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class Attachfilereport_reportId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_attachfileReports",
                table: "attachfileReports");

            migrationBuilder.DropColumn(
                name: "rportId",
                table: "attachfileReports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_attachfileReports",
                table: "attachfileReports",
                columns: new[] { "attachfileId", "reportId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_attachfileReports",
                table: "attachfileReports");

            migrationBuilder.AddColumn<int>(
                name: "rportId",
                table: "attachfileReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_attachfileReports",
                table: "attachfileReports",
                columns: new[] { "attachfileId", "rportId" });
        }
    }
}
