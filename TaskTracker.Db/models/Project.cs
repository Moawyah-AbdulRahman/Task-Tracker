namespace TaskTracker.Db;

public class Project
{
    public long ProjectId { get; set; }

    public string ProjectName { get; set; } = "";

    public ProjectState State { get; set; }

    public DateTime StartDate { get; set; }

    public ICollection<Team>? Teams { get; set; }
}