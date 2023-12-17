using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class AttshAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attachAssignments",
                columns: table => new
                {
                    assignmentId = table.Column<int>(type: "int", nullable: false),
                    attachfileId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_attachAssignments_assignmentId",
                table: "attachAssignments",
                column: "assignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachAssignments");
        }
    }
}
