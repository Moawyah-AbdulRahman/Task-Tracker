using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Db;

public class ProjectDbRepository : IProjectRepository
{
    private readonly TaskTrackerDbContext dbContext;
    private readonly IUserRepository userRepository;

    public ProjectDbRepository(TaskTrackerDbContext dbContext, IUserRepository userRepository)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
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

        if (userId is not null)
            projects = projects.Where(p => userRepository.UserCanAccessProject(userId.Value, p.ProjectId));

        if (state is not null)
            projects = projects.Where(p => p.State == state);

        if (startDate is not null)
            projects = projects.Where(p => p.StartDate.Equals(startDate));

        return projects.ToList();
    }

    public bool HasId(long pId)
    {
        return dbContext.Projects.Any(p => p.ProjectId == pId);
    }

    private IQueryable<Project> GetProjects()
    {
        return dbContext.Projects
            .Include(p => p.Teams);
    }
}