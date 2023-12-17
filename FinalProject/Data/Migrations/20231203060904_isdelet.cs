using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class isdelet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "Universities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "skills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "reportStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "reportLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "objectivesSkills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "objectives",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "Attachfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "assignments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "assignmentObjectives",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Teamleader_isdelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UniversitySupervisor_isdelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "apprenticeshipsObjectives",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "apprenticeships",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "skills");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "reportStatuses");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "reportLogs");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "objectivesSkills");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "objectives");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "Attachfiles");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "assignments");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "assignmentObjectives");

            migrationBuilder.DropColumn(
                name: "Teamleader_isdelete",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniversitySupervisor_isdelete",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "apprenticeshipsObjectives");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "apprenticeships");
        }
    }
}
