using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskTracker.Db.configurations;

internal class SprintEntityTypeConfiguration : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder
            .HasKey(s => s.Name);

        builder
            .HasOne(s => s.Team)
            .WithMany(t => t.Sprints);

        //builder
        //    .HasCheckConstraint(
        //        "sprint_task_belongs_to_sprint_team_member",
        //        "");
    }
}
