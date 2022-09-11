using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Db.Migrations
{
    public partial class FixDbReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.DropForeignKey(
                name: "FK_Increments_Tasks_ProjectId_TaskId",
                table: "Increments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Increments",
                table: "Increments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Increments",
                table: "Increments",
                column: "IncrementId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Increments_TaskId",
                table: "Increments",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Increments_Tasks_TaskId",
                table: "Increments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Increments_Tasks_TaskId",
                table: "Increments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Increments",
                table: "Increments");

            migrationBuilder.DropIndex(
                name: "IX_Increments_TaskId",
                table: "Increments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                columns: new[] { "ProjectId", "TaskId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Increments",
                table: "Increments",
                columns: new[] { "ProjectId", "TaskId", "IncrementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Increments_Tasks_ProjectId_TaskId",
                table: "Increments",
                columns: new[] { "ProjectId", "TaskId" },
                principalTable: "Tasks",
                principalColumns: new[] { "ProjectId", "TaskId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropColumn(
                name: "TableName",
                table: "Tasks");
        }
    }
}
