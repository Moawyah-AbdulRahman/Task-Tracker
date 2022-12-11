namespace TaskTracker.Db;

public class Team
{
    public long TeamId { get; set; }

    public string Name { get; set; } = "";

    public TeamState State { get; set; }

    public string TeamKeyPrefix { get; set; } = "";

    public long ProjectId { get; set; }

    public Project? Project { get; set; }

    public ICollection<User>? Members { get; set; }

    public ICollection<Sprint>? Sprints { get; set; }
}