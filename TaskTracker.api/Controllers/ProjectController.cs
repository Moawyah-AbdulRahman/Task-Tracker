using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Db;

namespace TaskTracker.api.Controllers;

[ApiController]
[Route("api/projects/")]
public class ProjectController : ControllerBase
{
    private readonly IProjectRepository projectRepository;
    private readonly IMapper mapper;

    public ProjectController(IProjectRepository projectRepository, IMapper mapper)
    {
        this.projectRepository = projectRepository
            ?? throw new ArgumentNullException(nameof(projectRepository));

        this.mapper = mapper
            ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("")]
    public IActionResult GetProjects(
        [FromQuery] long? userId,
        [FromQuery] ProjectState? state,
        [FromQuery] DateTime? startDate)
    {
        var projects = projectRepository.GetProjects(userId, state, startDate);

        if (!projects.Any())
            return NotFound();

        var projectDtos = mapper.Map<IEnumerable<ProjectDto>>(projects);
        return Ok(projectDtos);
    }

    [HttpPost("")]
    public IActionResult CreateProject([FromBody] CreateProjectDto createProjectDto)
    {
        var project = mapper.Map<Project>(createProjectDto);
        projectRepository.CreateProject(project);
        var projectDto = mapper.Map<ProjectDto>(project);

        return Created($"/api/projects/{project.ProjectId}", projectDto);
    }

    [HttpGet("{id}")]
    public IActionResult GetProject([FromRoute] long id)
    {
        //TODO:: Implement
        return Ok(new Project { ProjectId = id });
    }
}