using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskTracker.Db.configurations;

public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(t => t.TaskId);

        builder
            .HasOne(t => t.Sprint)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.SprintName);

        builder
            .HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.UserId);

        builder
            .HasCheckConstraint(
                "ck_task_can_be_assigned_to_sprint",
                "[dbo].[FnTaskBelongToSprint](TaskId, SprintName) = 1");

        builder
            .HasCheckConstraint(
                "ck_task_no_in_Progress_if_data_missing",
                "SprintName IS NOT NULL AND UserId IS NOT NULL AND StoryPointsValue IS NOT NULL OR State = 0");
    }
}