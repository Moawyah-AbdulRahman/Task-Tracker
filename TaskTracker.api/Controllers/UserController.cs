using Microsoft.AspNetCore.Mvc;
using TaskTracker.Db;

namespace TaskTracker.api;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository userRepository;

    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository ??
            throw new ArgumentNullException(nameof(userRepository));
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
            .ToDictionary(g => g.Key, g => g.ToList());

        return Ok(result);
    }
}