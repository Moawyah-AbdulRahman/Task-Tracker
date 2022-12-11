namespace TaskTracker.Db;

public interface IUserRepository
{
    bool HasId(long id);
    User? GetUser(long userId);
    IEnumerable<Task> GetTasks(long userId);
    IEnumerable<User> GetUsers(IEnumerable<long> userIds);
}