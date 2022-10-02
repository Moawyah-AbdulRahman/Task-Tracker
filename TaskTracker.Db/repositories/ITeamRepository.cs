namespace TaskTracker.Db;

public interface ITeamRepository
{
    void Add(Team team);

    bool HasId(long teamId);
}