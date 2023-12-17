using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class migrationApprenticeship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "apprenticeshipId",
                table: "assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "apprenticeships",
                columns: table => new
                {
                    apprenticeshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    teamleaderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    universitySupervisorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apprenticeships", x => x.apprenticeshipId);
                    table.ForeignKey(
                        name: "FK_apprenticeships_AspNetUsers_studentId",
                        column: x => x.studentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_apprenticeships_AspNetUsers_teamleaderId",
                        column: x => x.teamleaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_apprenticeships_AspNetUsers_universitySupervisorId",
                        column: x => x.universitySupervisorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignments_apprenticeshipId",
                table: "assignments",
                column: "apprenticeshipId");

            migrationBuilder.CreateIndex(
                name: "IX_apprenticeships_studentId",
                table: "apprenticeships",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_apprenticeships_teamleaderId",
                table: "apprenticeships",
                column: "teamleaderId");

            migrationBuilder.CreateIndex(
                name: "IX_apprenticeships_universitySupervisorId",
                table: "apprenticeships",
                column: "universitySupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_apprenticeships_apprenticeshipId",
                table: "assignments",
                column: "apprenticeshipId",
                principalTable: "apprenticeships",
                principalColumn: "apprenticeshipId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignments_apprenticeships_apprenticeshipId",
                table: "assignments");

            migrationBuilder.DropTable(
                name: "apprenticeships");

            migrationBuilder.DropIndex(
                name: "IX_assignments_apprenticeshipId",
                table: "assignments");

            migrationBuilder.DropColumn(
                name: "apprenticeshipId",
                table: "assignments");
        }
    }
}
