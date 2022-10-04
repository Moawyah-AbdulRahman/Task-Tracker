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
                )
            .ForMember(
                dest => dest.TableName,
                opt => opt.MapFrom(src => src.Name)
                );

        CreateMap<Task, TaskDto>()
            .ForMember(
                dest => dest.Assignee,
                opt => opt.MapFrom(src => src.UserId)
            )
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.TableName)
            );
    }
}