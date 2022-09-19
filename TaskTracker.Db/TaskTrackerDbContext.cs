using Microsoft.EntityFrameworkCore;
using TaskTracker.Db.configurations;

namespace TaskTracker.Db;
public class TaskTrackerDbContext : DbContext
{
    #nullable disable
    public DbSet<Increment> Increments { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<User> Users { get; set; }
    #nullable enable

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"
            Server=127.0.0.1,1433;
            Database=TaskTracker;
            User Id=SA;
            Password=yourStrong(!)Password"
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
    }
}
