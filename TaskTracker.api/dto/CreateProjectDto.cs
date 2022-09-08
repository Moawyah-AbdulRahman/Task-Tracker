using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateProjectDto
{
    public long OwnerId { get; set; }

    public string Name { get; set; } = "";

    public DateTime StartDate { get; set; }

    public ProjectState? State { get; set; }
}