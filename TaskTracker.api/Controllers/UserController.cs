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
        var tasks = userRepository.GetTasks(id);

        return Ok(new UserBoardDto(tasks));
    }
}