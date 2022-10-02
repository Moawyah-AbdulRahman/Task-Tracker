namespace TaskTracker.api;

public class CreateSprintDto
{
    public string SprintName { get; set; } = "";

    public long TeamId { get; set; }

    public DateTime StartDate { get; set; }

    public bool ShouldStartSprint { get; set; }

    public ICollection<long>? TaskIds { get; set; }
}