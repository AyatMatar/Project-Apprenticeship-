using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class AssignmentObjectives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assignmentObjectives",
                columns: table => new
                {
                    assignmentId = table.Column<int>(type: "int", nullable: false),
                    objectivesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignmentObjectives", x => new { x.assignmentId, x.objectivesId });
                    table.ForeignKey(
                        name: "FK_assignmentObjectives_assignments_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "assignments",
                        principalColumn: "assignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assignmentObjectives_objectivecs_objectivesId",
                        column: x => x.objectivesId,
                        principalTable: "objectivecs",
                        principalColumn: "objectivecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignmentObjectives_objectivesId",
                table: "assignmentObjectives",
                column: "objectivesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignmentObjectives");
        }
    }
}
