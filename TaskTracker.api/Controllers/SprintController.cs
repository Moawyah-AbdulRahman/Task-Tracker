using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Db;

namespace TaskTracker.api.Controllers;

[Route("api/sprints")]
[ApiController]
public class SprintController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ISprintRepository sprintRepository;

    public SprintController(IMapper mapper, ISprintRepository sprintRepository)
    {
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.sprintRepository = sprintRepository ?? throw new ArgumentNullException(nameof(sprintRepository));
    }

    [HttpPost("")]
    public IActionResult CreateSprint([FromBody] CreateSprintDto createSprintDto)
    {
        var sprint = mapper.Map<Sprint>(createSprintDto);
        sprintRepository.CreateSprint(sprint);
        var sprintDto = mapper.Map<SprintDto>(sprint);
        return Created($"api/sprints/{sprint.Name}", sprintDto);
    }
}
