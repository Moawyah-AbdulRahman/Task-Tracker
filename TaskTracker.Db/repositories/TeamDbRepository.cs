namespace TaskTracker.Db.repositories;

public class TeamDbRepository : ITeamRepository
{
    private readonly TaskTrackerDbContext dbContext;

    public TeamDbRepository(TaskTrackerDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
}