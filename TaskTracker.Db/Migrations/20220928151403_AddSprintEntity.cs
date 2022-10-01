using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Db.Migrations
{
    public partial class AddSprintEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_OwnerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks");

            migrationBuilder.DropCheckConstraint(
                name: "CK_user_can_access_project",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "SprintName",
                table: "Tasks",
                type: "nvarchar(450)",
                nullable: true
                );

            migrationBuilder.AddColumn<int>(
                name: "StoryPointsValue",
                table: "Tasks",
                type: "int",
                nullable: false
                );

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Sprints_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StoryPoints",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryPoints", x => x.Value);
                });

            migrationBuilder.InsertData(
                table: "StoryPoints",
                column: "Value",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    8,
                    13,
                    21
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SprintName",
                table: "Tasks",
                column: "SprintName");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StoryPointsValue",
                table: "Tasks",
                column: "StoryPointsValue");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_TeamId",
                table: "Sprints",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_SprintName",
                table: "Tasks",
                column: "SprintName",
                principalTable: "Sprints",
                principalColumn: "Name",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_StoryPoints_StoryPointsValue",
                table: "Tasks",
                column: "StoryPointsValue",
                principalTable: "StoryPoints",
                principalColumn: "Value",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_SprintName",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_StoryPoints_StoryPointsValue",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "StoryPoints");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SprintName",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StoryPointsValue",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SprintName",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StoryPointsValue",
                table: "Tasks");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Projects",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    AccessableProjectsProjectId = table.Column<long>(type: "bigint", nullable: false),
                    UsersUserID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.AccessableProjectsProjectId, x.UsersUserID });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_AccessableProjectsProjectId",
                        column: x => x.AccessableProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_user_can_access_project",
                table: "Tasks",
                sql: "[dbo].[FnUserCanAccessProject](UserId, OwnerId, ProjectName) = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UsersUserID",
                table: "ProjectUser",
                column: "UsersUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_OwnerId",
                table: "Projects",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
