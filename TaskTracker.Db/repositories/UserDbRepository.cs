using Microsoft.EntityFrameworkCore;

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

    public IEnumerable<Task> GetTasks(long userId)
    {
        return dbContext
            .Tasks
            .Where(t => t.UserId == userId);
    }

    public IEnumerable<User> GetUsers(IEnumerable<long> userIds)
    {
        return dbContext
            .Users
            .Where(u => userIds.Contains(u.UserID))
            .ToList();
    }

    public User? GetUser(long userId)
    {
        return dbContext
            .Users
            .Include(u => u.Team)
            .First(u => u.UserID == userId);
    }
}