namespace TaskTracker.Db;

public interface ISprintRepository
{
    void CreateSprint(Sprint sprint);

    bool HasName(string sprintName);
}
