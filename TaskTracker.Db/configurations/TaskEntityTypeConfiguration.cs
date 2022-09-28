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
            .HasOne(t => t.StoryPoints);
    }
}