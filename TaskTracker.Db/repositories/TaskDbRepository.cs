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

    public IEnumerable<Task> GetTasks(IEnumerable<long> ids)
    {
        return dbContext
            .Tasks
            .Where(t => ids.Contains(t.TaskId));
    }

    public bool HasId(long id)
    {
        return dbContext.Tasks.Any(t => t.TaskId == id);
    }

    public bool StoryPointsValueAvailable(int storyPointsValue)
    {
        return dbContext.StoryPoints.Contains(new StoryPoints { Value = storyPointsValue });
    }

    public void UpdateTask(Task task)
    {
        dbContext.Update(task);
        dbContext.SaveChanges();
    }
}