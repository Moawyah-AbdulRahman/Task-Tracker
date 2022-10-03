using AutoMapper;
using Task = TaskTracker.Db.Task;

namespace TaskTracker.api;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskDto, Task>()
            .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.Assignee)
            );

        CreateMap<Task, TaskDto>()
            .ForMember(
                dest => dest.Assignee,
                opt => opt.MapFrom(src => src.UserId)
            );
    }
}