using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class ObjectivesSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "objectivesSkills",
                columns: table => new
                {
                    ObjectivecId = table.Column<int>(type: "int", nullable: false),
                    skillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objectivesSkills", x => new { x.ObjectivecId, x.skillId });
                    table.ForeignKey(
                        name: "FK_objectivesSkills_objectivecs_ObjectivecId",
                        column: x => x.ObjectivecId,
                        principalTable: "objectivecs",
                        principalColumn: "objectivecId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objectivesSkills_skills_skillId",
                        column: x => x.skillId,
                        principalTable: "skills",
                        principalColumn: "skillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_objectivesSkills_skillId",
                table: "objectivesSkills",
                column: "skillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "objectivesSkills");
        }
    }
}
