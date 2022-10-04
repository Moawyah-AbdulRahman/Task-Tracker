using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Db;

public class ProjectDbRepository : IProjectRepository
{
    private readonly TaskTrackerDbContext dbContext;

    public ProjectDbRepository(TaskTrackerDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void CreateProject(Project project)
    {
        dbContext.Add(project);
        dbContext.SaveChanges();
    }

    public IEnumerable<Project> GetProjects(long? userId, ProjectState? state,
        DateTime? startDate)
    {
        var projects = GetProjects();

        if(userId is not null)
            projects = projects.Where(p=>p.OwnerId == userId || p.Users!.Any(u =>u.UserID == userId));

        if (state is not null)
            projects = projects.Where(p => p.State == state);

        if (startDate is not null)
            projects = projects.Where(p => p.StartDate.Equals(startDate));

        return projects.ToList();
    }

    private IQueryable<Project> GetProjects()
    {
        return dbContext.Projects
            .Include(p => p.Users)
            .Include(p => p.Tasks);
    }
}