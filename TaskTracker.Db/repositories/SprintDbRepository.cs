namespace TaskTracker.Db;

public class SprintDbRepository : ISprintRepository
{
    private readonly TaskTrackerDbContext dbContext;

    public SprintDbRepository(TaskTrackerDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void CreateSprint(Sprint sprint)
    {
        if (sprint.IsActive)
        {
            var activeSprint = dbContext
                .Sprints
                .Where(
                    s =>
                        s.TeamId == sprint.TeamId &&
                        s.IsActive
                    )
                .FirstOrDefault();

            if (activeSprint is not null)
            {
                activeSprint.IsActive = false;
                dbContext.Sprints.Update(activeSprint);
            }
        }

        dbContext.Sprints.Add(sprint);
        dbContext.SaveChanges();
    }

    public bool HasName(string sprintName)
    {
        return dbContext
            .Sprints
            .Any(s => s.Name == sprintName);
    }
}
