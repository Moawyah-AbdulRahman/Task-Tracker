using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskTracker.api;
using TaskTracker.api.Controllers;
using TaskTracker.Db;
using Task = TaskTracker.Db.Task;

namespace TaskTracker.tests;

public class TaskControllerShould
{
    private readonly Mock<ITaskRepository> mockTaskRepo;
    private readonly TaskController taskController;
    public TaskControllerShould()
    {
        mockTaskRepo = new Mock<ITaskRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TaskProfile>();
        });

        IMapper mapper = config.CreateMapper();
        taskController = new TaskController(mapper, mockTaskRepo.Object);
    }

    [Fact]
    public void CreateCallsCreateFromRepo()
    {
        taskController.CreateTask(new CreateTaskDto());

        mockTaskRepo.Verify(r => r.CreateTask(It.IsAny<Task>()));
    }

    [Fact]
    public void CreateReturns201()
    {
        var result = taskController.CreateTask(new CreateTaskDto());

        Assert.IsType<CreatedResult>(result);
    }

}