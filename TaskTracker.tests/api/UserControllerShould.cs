using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskTracker.api;
using TaskTracker.Db;
using Task = TaskTracker.Db.Task;

namespace TaskTracker.tests;

public class UserControllerShould
{
    private readonly Mock<IUserRepository> mockUserRepo;
    private readonly UserController userController;

    public UserControllerShould()
    {
        mockUserRepo = new Mock<IUserRepository>();
        this.userController = new UserController(mockUserRepo.Object);
    }

    [Fact]
    public void BoardReturns404IfUserNotInRepo()
    {
        mockUserRepo
            .Setup(r => r.HasId(It.IsAny<long>()))
            .Returns(false);

        var result = userController.GetBoard(5);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void BoardReturns200IfUserExistInRepo()
    {
        mockUserRepo
            .Setup(r => r.HasId(It.IsAny<long>()))
            .Returns(true);

        var result = userController.GetBoard(5);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void BoardReturnsAllTasksSeparatedCorrectly()
    {
        mockUserRepo
            .Setup(r => r.HasId(It.IsAny<long>()))
            .Returns(true);

        mockUserRepo
            .Setup(r => r.GetTasks(It.IsAny<long>()))
            .Returns(new Task[]{
                new Task{TaskId=1,State=TaskState.ToDo},
                new Task{TaskId=2,State=TaskState.ToDo},
                new Task{TaskId=3,State=TaskState.InProgress},
                new Task{TaskId=4,State=TaskState.Review},
                new Task{TaskId=5,State=TaskState.Testing},
                new Task{TaskId=6,State=TaskState.Done},
            });

        var result = (userController.GetBoard(5) as OkObjectResult)
            ?.Value as Dictionary<TaskState, List<Task>>;

        var todo = result?.GetValueOrDefault(TaskState.ToDo);
        Assert.True(todo?.All(t => t.State == TaskState.ToDo) ?? true);
        Assert.Equal(todo?.Count() ?? 0, 2);

        var inProgress = result?.GetValueOrDefault(TaskState.InProgress);
        Assert.True(inProgress?.All(t => t.State == TaskState.InProgress) ?? true);
        Assert.Equal(inProgress?.Count() ?? 0, 1);

        var review = result?.GetValueOrDefault(TaskState.Review);
        Assert.True(review?.All(t => t.State == TaskState.Review) ?? true);
        Assert.Equal(review?.Count() ?? 0, 1);

        var testing = result?.GetValueOrDefault(TaskState.Testing);
        Assert.True(testing?.All(t => t.State == TaskState.Testing) ?? true);
        Assert.Equal(testing?.Count() ?? 0, 1);

        var done = result?.GetValueOrDefault(TaskState.Done);
        Assert.True(done?.All(t => t.State == TaskState.Done));
        Assert.Equal(done?.Count() ?? 0, 1);
    }
}