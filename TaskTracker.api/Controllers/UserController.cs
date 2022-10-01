using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Db;

namespace TaskTracker.api;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository ??
            throw new ArgumentNullException(nameof(userRepository));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("{id}/board")]
    public IActionResult GetBoard([FromRoute] long id)
    {
        if (!userRepository.HasId(id))
        {
            return NotFound();
        }

        var tasks = userRepository.GetTasks(id);
        var result = tasks
            .GroupBy(t => t.State)
            .ToDictionary(g => g.Key, g => mapper.Map<IEnumerable<TaskDto>>(g.ToList()));

        return Ok(result);
    }
}