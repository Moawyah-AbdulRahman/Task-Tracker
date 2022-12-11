using TaskTracker.Db;

namespace TaskTracker.api;

public class TeamDto
{
    public long TeamId { get; set; }

    public string Name { get; set; } = "";

    public TeamState State { get; set; }

    public string TeamKeyPrefix { get; set; } = "";

    public long ProjectId { get; set; }

    public ICollection<long> MemberIds { get; set; } = new List<long>();
}