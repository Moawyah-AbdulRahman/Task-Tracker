namespace TaskTracker.Db;

public interface IUserRepository
{
    bool HasId(long id);
}