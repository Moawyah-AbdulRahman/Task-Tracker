using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Db.Migrations
{
    public partial class FixTaskEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Tasks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "StoryPointsValue",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddCheckConstraint(
                name: "ck_task_no_in_Progress_if_data_missing",
                table: "Tasks",
                sql: "SprintName IS NOT NULL AND UserId IS NOT NULL AND StoryPointsValue IS NOT NULL OR State = 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropCheckConstraint(
                name: "ck_task_no_in_Progress_if_data_missing",
                table: "Tasks");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoryPointsValue",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}