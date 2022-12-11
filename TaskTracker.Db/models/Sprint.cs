namespace TaskTracker.Db;

public class Sprint
{
    public string Name { get; set; } = "";

    public DateTime StartDate { get; set; }

    public bool IsActive { get; set; }

    public long TeamId { get; set; }

    public Team? Team { get; set; }

    public ICollection<Task>? Tasks { get; set; }
}
