using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskTracker.Db.configurations;

public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder
            .HasKey(t=>t.TeamId);

        builder
            .HasMany(t=>t.Members)
            .WithOne(u=>u.Team);
        
        builder
            .HasOne(t=>t.Project)
            .WithMany(p=>p.Teams);
    }
}