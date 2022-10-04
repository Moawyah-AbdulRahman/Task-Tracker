using TaskTracker.Db;

namespace TaskTracker.api;

public class ProjectDto
{
    public long ProjectId { get; set; }

    public string ProjectName { get; set; } = "";

    public long OwnerId { get; set; }

    public ProjectState State { get; set; }

    public DateTime StartDate { get; set; }

    public ICollection<long>? Users { get; set; }

    public ICollection<long>? Tasks { get; set; }
}