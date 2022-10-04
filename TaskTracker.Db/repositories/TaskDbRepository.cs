namespace TaskTracker.Db;

public class TaskDbRepository : ITaskRepository
{
    private readonly TaskTrackerDbContext dbContext;

    public TaskDbRepository(TaskTrackerDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void CreateTask(Task task)
    {
        dbContext.Add(task);
        dbContext.SaveChanges();
    }
}