using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Db.Migrations
{
    public partial class AddConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
	            CREATE FUNCTION [dbo].[FnTaskCanBelongToSprint]
				(
					@taskId BIGINT,
					@sprintName VARCHAR(450)
				)
				RETURNS BIT
				AS
				BEGIN
					DECLARE @result BIT

					IF @taskId IN (
							SELECT TaskId
							FROM Tasks
							WHERE UserId IN (
								SELECT UserId
								FROM Users
								WHERE TeamId IN (
									SELECT teamId
									FROM Sprints
									WHERE [Name] = @sprintName
									)
								)
							)
						OR @sprintName is null
						SET @result = 1;
					ELSE 
						SET @result = 0;
					RETURN @result
				END");

            migrationBuilder.AddCheckConstraint(
                name: "ck_task_can_be_assigned_to_sprint",
                table: "Tasks",
                sql: "[dbo].[FnTaskCanBelongToSprint](TaskId, SprintName) = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_task_can_be_assigned_to_sprint",
                table: "Tasks");

			migrationBuilder.Sql("DROP FUNCTION [dbo].[FnTaskCanBelongToSprint]");
        }
    }
}
