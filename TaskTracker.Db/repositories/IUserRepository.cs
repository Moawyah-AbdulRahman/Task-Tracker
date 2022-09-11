namespace TaskTracker.Db;

public interface IUserRepository
{
    bool HasId(long id);
    bool UserCanAccessProject(long userId, long projectId);
}