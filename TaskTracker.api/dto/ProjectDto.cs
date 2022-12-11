using TaskTracker.Db;

namespace TaskTracker.api;

public class ProjectDto
{
    public long ProjectId { get; set; }

    public string ProjectName { get; set; } = "";

    public ProjectState State { get; set; }

    public DateTime StartDate { get; set; }

    public IEnumerable<long>? TeamIds { get; set; }
}