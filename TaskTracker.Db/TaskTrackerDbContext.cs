using Microsoft.EntityFrameworkCore;
using TaskTracker.Db.configurations;

namespace TaskTracker.Db;
public class TaskTrackerDbContext : DbContext
{
#nullable disable
    public DbSet<Increment> Increments { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Sprint> Sprints { get; set; }

    public DbSet<StoryPoints> StoryPoints { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<User> Users { get; set; }
#nullable enable

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"
            Data Source=(localdb)\ProjectModels;
            Initial Catalog=TaskTrackerDb;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=False;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False"
         );
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

        new ProjectEntityTypeConfiguration().Configure(modelBuilder.Entity<Project>());

        new TaskEntityTypeConfiguration().Configure(modelBuilder.Entity<Task>());

        new IncrementEntityTypeConfiguration().Configure(modelBuilder.Entity<Increment>());

        new TeamEntityTypeConfiguration().Configure(modelBuilder.Entity<Team>());

        new SprintEntityTypeConfiguration().Configure(modelBuilder.Entity<Sprint>());

        new StoryPointsEntityTypeConfiguration().Configure(modelBuilder.Entity<StoryPoints>());
    }
}
