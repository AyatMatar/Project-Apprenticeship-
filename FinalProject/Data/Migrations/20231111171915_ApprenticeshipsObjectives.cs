using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class ApprenticeshipsObjectives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apprenticeshipsObjectives",
                columns: table => new
                {
                    apprenticeshipId = table.Column<int>(type: "int", nullable: false),
                    objectivesId = table.Column<int>(type: "int", nullable: false),
                    objectivecId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apprenticeshipsObjectives", x => new { x.objectivesId, x.apprenticeshipId });
                    table.ForeignKey(
                        name: "FK_apprenticeshipsObjectives_apprenticeships_apprenticeshipId",
                        column: x => x.apprenticeshipId,
                        principalTable: "apprenticeships",
                        principalColumn: "apprenticeshipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_apprenticeshipsObjectives_objectivecs_objectivecId",
                        column: x => x.objectivecId,
                        principalTable: "objectivecs",
                        principalColumn: "objectivecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apprenticeshipsObjectives_apprenticeshipId",
                table: "apprenticeshipsObjectives",
                column: "apprenticeshipId");

            migrationBuilder.CreateIndex(
                name: "IX_apprenticeshipsObjectives_objectivecId",
                table: "apprenticeshipsObjectives",
                column: "objectivecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apprenticeshipsObjectives");
        }
    }
}
