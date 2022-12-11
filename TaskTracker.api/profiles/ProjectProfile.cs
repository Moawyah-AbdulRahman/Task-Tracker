using AutoMapper;
using TaskTracker.Db;

namespace TaskTracker.api;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>()
            .ForMember(
                dest => dest.TeamIds,
                opt => opt.MapFrom(src => src.Teams!.Select(t => t.TeamId))
            );

        CreateMap<CreateProjectDto, Project>()
            .ForMember(
                dest => dest.ProjectName,
                opt => opt.MapFrom(src => src.Name)
            );
    }
}