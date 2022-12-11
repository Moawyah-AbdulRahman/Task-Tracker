using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Db;

namespace TaskTracker.api.Controllers;

[ApiController]
[Route("api/teams")]
public class TeamController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ITeamRepository teamRepository;
    private readonly IUserRepository userRepository;

    public TeamController(IMapper mapper, ITeamRepository teamRepository, IUserRepository userRepository)
    {
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    [HttpPost("")]
    public IActionResult CreateTeam([FromBody] CreateTeamDto createTeamDto)
    {
        var team = mapper.Map<Team>(createTeamDto);
        teamRepository.Add(team);
        return Created($"api/teams/{team.TeamId}", mapper.Map<TeamDto>(team));
    }
}