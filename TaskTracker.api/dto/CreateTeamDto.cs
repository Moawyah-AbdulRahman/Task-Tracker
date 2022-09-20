using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateTeamDto
{
    public string Name { get; set; } = "";

    public long ProjectId { get; set; }

    public ICollection<long> MemberIds { get; set; } = new List<long>();

    public TeamState State { get; set; }

    public string TeamKeyPrefix { get; set; } = "";
}