using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Db;
using Task = TaskTracker.Db.Task;

namespace TaskTracker.api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ITaskRepository taskRepository;

    public TaskController(IMapper mapper, ITaskRepository taskRepository)
    {
        this.mapper = mapper 
            ?? throw new ArgumentNullException(nameof(mapper));
        this.taskRepository = taskRepository 
            ?? throw new ArgumentNullException(nameof(taskRepository));
    }

    [HttpPost("")]
    public IActionResult CreateTask([FromBody] CreateTaskDto createTaskDto)
    {
        var task = mapper.Map<Task>(createTaskDto);
        taskRepository.CreateTask(task);
        var taskDto = mapper.Map<TaskDto>(task);
        return Created($"/api/tasks/{task.TaskId}",taskDto);
    }
}