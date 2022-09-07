namespace TaskTracker.Db;

public interface IProjectRepository
{
    public IEnumerable<Project> GetProjects(long? userId, ProjectState? state,
        DateTime? startDate);
}