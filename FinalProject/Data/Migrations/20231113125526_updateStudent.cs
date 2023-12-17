using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class updateStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniversitySupervisor_UniversityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UniversitySupervisor_UniversityId",
                table: "AspNetUsers",
                column: "UniversitySupervisor_UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Universities_UniversitySupervisor_UniversityId",
                table: "AspNetUsers",
                column: "UniversitySupervisor_UniversityId",
                principalTable: "Universities",
                principalColumn: "universityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Universities_UniversitySupervisor_UniversityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UniversitySupervisor_UniversityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniversitySupervisor_UniversityId",
                table: "AspNetUsers");
        }
    }
}
