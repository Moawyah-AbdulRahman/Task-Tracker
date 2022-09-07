using AutoMapper;
using TaskTracker.Db;

namespace TaskTracker.api;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>()
            .ForMember(
                dest => dest.Tasks,
                opt=>opt.MapFrom(src=>src.Tasks!.Select(t=>t.TaskId))
            )
            .ForMember(
                dest=>dest.Users,
                opt=>opt.MapFrom(src=>src.Users!.Select(u=>u.UserID))
            );
    }
}