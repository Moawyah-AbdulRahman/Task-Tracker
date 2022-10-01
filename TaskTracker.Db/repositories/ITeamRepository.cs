namespace TaskTracker.Db;

public interface ITeamRepository
{
    void Add(Team team);

    //IEnumerable<Team> GetTeams(IEnumerable<long> teamIds);

    //bool HasId(long teamId);
}