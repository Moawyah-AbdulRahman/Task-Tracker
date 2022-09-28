namespace TaskTracker.Db;

public class Task
{
    public long TaskId { get; set; }

    public string SprintName { get; set; } = "";

    public long UserId { get; set; }

    public string Name { get; set; } = "";

    public TaskState State { get; set; }

    public StoryPoints StoryPoints { get; set; }

    public Sprint? Sprint { get; set; }

    public User? User { get; set; }

    public ICollection<Increment>? Increments { get; set; }
}