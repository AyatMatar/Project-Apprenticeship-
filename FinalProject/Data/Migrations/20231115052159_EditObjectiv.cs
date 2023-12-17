using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    public partial class EditObjectiv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apprenticeshipsObjectives_objectivecs_objectivecId",
                table: "apprenticeshipsObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_assignmentObjectives_objectivecs_objectivesId",
                table: "assignmentObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_objectivesSkills_objectivecs_ObjectivecId",
                table: "objectivesSkills");

            migrationBuilder.DropTable(
                name: "objectivecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_apprenticeshipsObjectives",
                table: "apprenticeshipsObjectives");

            migrationBuilder.DropIndex(
                name: "IX_apprenticeshipsObjectives_objectivecId",
                table: "apprenticeshipsObjectives");

            migrationBuilder.DropColumn(
                name: "objectivesId",
                table: "apprenticeshipsObjectives");

            migrationBuilder.RenameColumn(
                name: "objectivecId",
                table: "apprenticeshipsObjectives",
                newName: "objectiveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_apprenticeshipsObjectives",
                table: "apprenticeshipsObjectives",
                columns: new[] { "objectiveId", "apprenticeshipId" });

            migrationBuilder.CreateTable(
                name: "objectives",
                columns: table => new
                {
                    objectiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    objectivecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objectives", x => x.objectiveId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_apprenticeshipsObjectives_objectives_objectiveId",
                table: "apprenticeshipsObjectives",
                column: "objectiveId",
                principalTable: "objectives",
                principalColumn: "objectiveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentObjectives_objectives_objectivesId",
                table: "assignmentObjectives",
                column: "objectivesId",
                principalTable: "objectives",
                principalColumn: "objectiveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_objectivesSkills_objectives_ObjectivecId",
                table: "objectivesSkills",
                column: "ObjectivecId",
                principalTable: "objectives",
                principalColumn: "objectiveId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apprenticeshipsObjectives_objectives_objectiveId",
                table: "apprenticeshipsObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_assignmentObjectives_objectives_objectivesId",
                table: "assignmentObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_objectivesSkills_objectives_ObjectivecId",
                table: "objectivesSkills");

            migrationBuilder.DropTable(
                name: "objectives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_apprenticeshipsObjectives",
                table: "apprenticeshipsObjectives");

            migrationBuilder.RenameColumn(
                name: "objectiveId",
                table: "apprenticeshipsObjectives",
                newName: "objectivecId");

            migrationBuilder.AddColumn<int>(
                name: "objectivesId",
                table: "apprenticeshipsObjectives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_apprenticeshipsObjectives",
                table: "apprenticeshipsObjectives",
                columns: new[] { "objectivesId", "apprenticeshipId" });

            migrationBuilder.CreateTable(
                name: "objectivecs",
                columns: table => new
                {
                    objectivecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    objectivecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objectivecs", x => x.objectivecId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apprenticeshipsObjectives_objectivecId",
                table: "apprenticeshipsObjectives",
                column: "objectivecId");

            migrationBuilder.AddForeignKey(
                name: "FK_apprenticeshipsObjectives_objectivecs_objectivecId",
                table: "apprenticeshipsObjectives",
                column: "objectivecId",
                principalTable: "objectivecs",
                principalColumn: "objectivecId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentObjectives_objectivecs_objectivesId",
                table: "assignmentObjectives",
                column: "objectivesId",
                principalTable: "objectivecs",
                principalColumn: "objectivecId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_objectivesSkills_objectivecs_ObjectivecId",
                table: "objectivesSkills",
                column: "ObjectivecId",
                principalTable: "objectivecs",
                principalColumn: "objectivecId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
