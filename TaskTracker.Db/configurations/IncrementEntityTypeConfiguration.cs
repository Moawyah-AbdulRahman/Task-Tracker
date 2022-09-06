using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskTracker.Db.configurations;

public class IncrementEntityTypeConfiguration : IEntityTypeConfiguration<Increment>
{
    public void Configure(EntityTypeBuilder<Increment> builder)
    {
        builder
            .HasKey(i => new { i.ProjectId, i.TaskId, i.IncrementId });

        builder
            .HasOne(i => i.Task)
            .WithMany(t => t.Increments)
            .HasForeignKey(i => new { i.ProjectId, i.TaskId });
    }
}