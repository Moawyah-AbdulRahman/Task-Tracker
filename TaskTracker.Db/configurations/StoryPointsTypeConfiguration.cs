using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskTracker.Db.configurations;

public class StoryPointsEntityTypeConfiguration : IEntityTypeConfiguration<StoryPoints>
{
    public void Configure(EntityTypeBuilder<StoryPoints> builder)
    {
        builder.HasKey(sp => sp.Value);

        builder
            .HasData(
                new { Value = 1 },
                new { Value = 2 },
                new { Value = 3 },
                new { Value = 4 },
                new { Value = 8 },
                new { Value = 13 },
                new { Value = 21 }
                );

    }
}