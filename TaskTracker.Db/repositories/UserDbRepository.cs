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

    public bool UserCanAccessProject(long userId, long projectId)
    {
        return dbContext
            .Projects.Include(p => p.Users)
            .Any(
                p =>
                    p.ProjectId == projectId &&
                    (p.OwnerId == userId || p.Users!.Any(u => u.UserID == userId))
                );
    }

    public IEnumerable<Task> GetTasks(long userId)
    {
        return dbContext
            .Tasks
            .Where(t => t.UserId == userId);
    }
}