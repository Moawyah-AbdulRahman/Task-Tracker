using AutoMapper;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.api.Controllers;
using TaskTracker.Db;
using TaskTracker.api;

namespace TaskTracker.tests;

public class ProjectControllerShould
{
    private readonly Mock<IProjectRepository> mockProjectRepo;
    private readonly ProjectController projectController;

    public ProjectControllerShould()
    {

        mockProjectRepo = new Mock<IProjectRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProjectProfile>();
        });

        IMapper iMapper = config.CreateMapper();
        projectController = new ProjectController(mockProjectRepo.Object, iMapper);
    }

    [Fact]
    public void GetReturns404StatusIfNoProjectIsFound()
    {
        mockProjectRepo
            .Setup(r => r.GetProjects(null, null, null))
            .Returns(Enumerable.Empty<Project>());

        var result = projectController.GetProjects(null, null, null);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetRetruns200StatusIfProjectIsFound()
    {
        mockProjectRepo
            .Setup(r => r.GetProjects(null, null, null))
            .Returns(new Project[] { new Project { ProjectId = 1 } });

        var result = projectController.GetProjects(null, null, null);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetReturnsTheCorrectNumberOfProjects()
    {
        mockProjectRepo
            .Setup(r => r.GetProjects(null, null, null))
            .Returns(new Project[] { new Project { ProjectId = 1 }, new Project { ProjectId = 2 } });

        var result = projectController.GetProjects(null, null, null);

        Assert.Equal(mockProjectRepo.Object.GetProjects(null, null, null).Count(), 2);
    }

    [Fact]
    public void GetCallsGetProjectsFromRepo()
    {
        mockProjectRepo
            .Setup(r => r.GetProjects(null, null, null))
            .Returns(new Project[] { new Project { ProjectId = 1 } });

        var result = projectController.GetProjects(null, null, null);

        mockProjectRepo.Verify(r => r.GetProjects(It.IsAny<long?>(), It.IsAny<ProjectState?>(), It.IsAny<DateTime?>()));
    }

    [Fact]
    public void CreateReturns201Status()
    {
        var result = projectController.CreateProject(new CreateProjectDto());
        Assert.IsType<CreatedResult>(result);
    }

    [Fact]
    public void CreateCallsCreateProjectFromRepo()
    {
        projectController.CreateProject(new CreateProjectDto());

        mockProjectRepo.Verify(r => r.CreateProject(It.IsAny<Project>()));
    }

    [Fact]
    public void CreateReturnsCorrectObject()
    {
        var createProjectDto = new CreateProjectDto
        {
            Name = "name",
            OwnerId = 17,
            State = ProjectState.Active,
            StartDate = new DateTime(2022, 1, 1)
        };

        var projectDto = new ProjectDto
        {
            ProjectName = "name",
            OwnerId = 17,
            State = ProjectState.Active,
            StartDate = new DateTime(2022, 1, 1)
        };

        var controllerResult = projectController.CreateProject(createProjectDto) as CreatedResult;
        var returnedObject = controllerResult?.Value as ProjectDto ?? throw new Exception();

        Assert.Equal(returnedObject.ProjectName, projectDto.ProjectName);
        Assert.Equal(returnedObject.OwnerId, projectDto.OwnerId);
        Assert.Equal(returnedObject.State, projectDto.State);
        Assert.Equal(returnedObject.StartDate, projectDto.StartDate);
    }
}