using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateTaskDto
{
    public long ProjectId { get; set; }

    public long Assignee { get; set; }

    public string Name { get; set; } = "";

    public TaskState State { get; set; }

}