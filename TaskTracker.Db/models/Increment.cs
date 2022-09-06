namespace TaskTracker.Db;

public class Increment
{
    public long IncrementId { get; set; }

    public long TaskId { get; set; }

    public long ProjectId { get; set; }

    public Task? Task { get; set; }
}