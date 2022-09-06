using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Db.Migrations
{
    public partial class TaskAccessConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE FUNCTION [dbo].[FnUserCanAccessProject] (
                @UserId AS BIGINT,
                @ProjectId BIGINT
            )
            RETURNS BIT
            BEGIN
                DECLARE @Result BIT
                IF
                    @UserId in (
                            SELECT  UsersUserID
                            FROM    ProjectUser
                            WHERE   AccessableProjectsProjectId = @ProjectId
                        UNION
                            SELECT  OwnerId
                            FROM    Projects AS p
                            WHERE   p.ProjectId = @ProjectId
                        )
                    SET @Result = 1;
                ELSE
                    SET @Result = 0;
                
                RETURN @Result;
            END;
            ");
            
            migrationBuilder.AddCheckConstraint(
                name: "CK_user_can_access_project",
                table: "Tasks",
                sql: "[dbo].[FnUserCanAccessProject](UserId, ProjectId) = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_user_can_access_project",
                table: "Tasks");

            migrationBuilder.Sql("DROP FUNCTION [dbo].[FnUserCanAccessProject]");
        }

    }
}
