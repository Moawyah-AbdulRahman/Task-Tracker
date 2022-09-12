using TaskTracker.Db;
using Task = TaskTracker.Db.Task;

namespace TaskTracker.api;

public class UserBoardDto
{
    public UserBoardDto(IEnumerable<Task> projects)
    {
        var dict = new Dictionary<TaskState, List<Task>>();

        foreach (var grp in projects.GroupBy(t => t.State))
        {
            dict[grp.Key] = grp.ToList();
        }
        ToDo = dict.GetValueOrDefault(TaskState.ToDo) ?? Enumerable.Empty<Task>();
        InProgress = dict.GetValueOrDefault(TaskState.InProgress) ?? Enumerable.Empty<Task>();
        Testing = dict.GetValueOrDefault(TaskState.Testing) ?? Enumerable.Empty<Task>();
        Review = dict.GetValueOrDefault(TaskState.Review) ?? Enumerable.Empty<Task>();
        Done = dict.GetValueOrDefault(TaskState.Done) ?? Enumerable.Empty<Task>();
    }
    public IEnumerable<Task> ToDo { get; }
    public IEnumerable<Task> InProgress { get; }
    public IEnumerable<Task> Testing { get; }
    public IEnumerable<Task> Review { get; }
    public IEnumerable<Task> Done { get; }
}