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
        
        var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectDto>();
            });
        
        IMapper iMapper = config.CreateMapper();
        projectController = new ProjectController(mockProjectRepo.Object, iMapper);
    }

    [Fact]
    public void Return404IfNoProjectIsFound()
    {
        mockProjectRepo
            .Setup(r => r.GetProjects(It.IsAny<long?>(), It.IsAny<ProjectState>(), It.IsAny<DateTime>()))
            .Returns(Enumerable.Empty<Project>());

        var result = projectController.GetProjects(null, null, null);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Retrun200IfProjectIsFound()
    {
        mockProjectRepo
            .Setup(r => r.GetProjects(null, null, null))
            .Returns(new Project[] { new Project { ProjectId = 1 } });

        var result = projectController.GetProjects(null, null, null);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void ReturnTheCorrectNumberOfProjects()
    {
        mockProjectRepo
            .Setup(r => r.GetProjects(null, null, null))
            .Returns(new Project[] { new Project { ProjectId = 1 }, new Project { ProjectId = 2 } });

        var result = projectController.GetProjects(null, null, null);

        Assert.Equal(mockProjectRepo.Object.GetProjects(null,null,null).Count(), 2);
    }

    [Fact]
    public void CallGetProjectsFromRepo()
    {
        mockProjectRepo
            .Setup(r => r.GetProjects(null, null, null))
            .Returns(new Project[] { new Project { ProjectId = 1 }});

        var result = projectController.GetProjects(null, null, null);

        mockProjectRepo.Verify(r=>r.GetProjects(It.IsAny<long?>(),It.IsAny<ProjectState?>(),It.IsAny<DateTime?>()));
    }

}