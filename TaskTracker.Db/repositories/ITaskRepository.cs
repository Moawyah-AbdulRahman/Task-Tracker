
namespace TaskTracker.Db;

public interface ITaskRepository
{
    void CreateTask(Task task);

    IEnumerable<Task> GetTasks(IEnumerable<long> ids);

    void UpdateTask(Task task);

    bool HasId(long id);

    bool StoryPointsValueAvailable(int storyPointsValue);
}