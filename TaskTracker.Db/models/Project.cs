namespace TaskTracker.Db;

public class Project
{
    public long ProjectId { get; set; }

    public string ProjectName { get; set; } = "";

    public long OwnerId { get; set; }

    public ProjectState State { get; set; }

    public DateTime StartDate { get; set; }

    public User? Owner { get; set; }

    public ICollection<User>? Users { get; set; }

    public ICollection<Task>? Tasks { get; set; }

    public ICollection<Team>? Teams { get; set; }
}