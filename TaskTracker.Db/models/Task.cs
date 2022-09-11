namespace TaskTracker.Db;

public class Task
{
    public long TaskId { get; set; }

    public long ProjectId { get; set; }

    public long UserId { get; set; }

    public string TableName { get; set; } = "";

    public TaskState State { get; set; }

    public Project? Project { get; set; }

    public User? User { get; set; }

    public ICollection<Increment>? Increments { get; set; }
}