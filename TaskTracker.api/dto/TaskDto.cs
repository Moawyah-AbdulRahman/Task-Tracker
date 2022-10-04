using TaskTracker.Db;

namespace TaskTracker.api;

public class TaskDto
{
    public long TaskId { get; set; }

    public long ProjectId { get; set; }

    public long Assignee { get; set; }

    public TaskState State { get; set; }

    public string Name { get; set; } = "";
}