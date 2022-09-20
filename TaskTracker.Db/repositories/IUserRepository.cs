namespace TaskTracker.Db;

public interface IUserRepository
{
    bool HasId(long id);
    bool UserCanAccessProject(long userId, long projectId);
    IEnumerable<Task> GetTasks(long userId);
    IEnumerable<User> GetUsers(IEnumerable<long> userIds);
}