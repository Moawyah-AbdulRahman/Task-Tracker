namespace TaskTracker.Db;

public class UserDbRepository : IUserRepository
{
    private readonly TaskTrackerDbContext dbContext;

    public UserDbRepository(TaskTrackerDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    }

    public bool HasId(long id)
    {
        return dbContext.Users.Any(u => u.UserID == id);
    }
}