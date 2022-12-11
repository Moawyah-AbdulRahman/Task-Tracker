namespace TaskTracker.Db;

public class TeamDbRepository : ITeamRepository
{
    private readonly TaskTrackerDbContext dbContext;

    public TeamDbRepository(TaskTrackerDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void Add(Team team)
    {
        var teamMembers = team.Members ?? Enumerable.Empty<User>();
        team.Members = null;
        foreach (var member in teamMembers)
        {
            member.Team = team;
        }

        dbContext.Teams.Add(team);
        dbContext.UpdateRange(teamMembers);
        dbContext.SaveChanges();
    }

    public bool HasId(long teamId)
    {
        return dbContext.Teams.Any(t => t.TeamId == teamId);
    }
}