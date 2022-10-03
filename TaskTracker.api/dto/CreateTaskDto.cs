using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateTaskDto
{
    public string Name { get; set; } = "";

    public long? Assignee { get; set; }

    public TaskState State { get; set; }

    public int? StoryPointsValue { get; set; }

    public string? SprintName { get; set; }
}