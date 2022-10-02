using AutoMapper;
using TaskTracker.Db;

namespace TaskTracker.api.profiles;

public class SprintProfile : Profile
{
	public SprintProfile(ITaskRepository taskRepository)
	{
		CreateMap<CreateSprintDto, Sprint>()
			.ForMember(
				dest => dest.Name,
				opt => opt.MapFrom(dest => dest.SprintName)
			)
			.ForMember(
				dest => dest.IsActive,
				opt => opt.MapFrom(dest => dest.ShouldStartSprint)
			)
			.ForMember(
				dest => dest.Tasks,
				opt => opt.MapFrom(src => taskRepository.GetTasks(src.TaskIds ?? Enumerable.Empty<long>()))
			);

		CreateMap<Sprint, SprintDto>()
			.ForMember(
				dest => dest.SprintName,
				opt => opt.MapFrom(dest => dest.Name)
			)
			.ForMember(
				dest => dest.ShouldStartSprint,
				opt => opt.MapFrom(src => src.IsActive)
			)
			.ForMember(
				dest => dest.TaskIds,
				opt => opt.MapFrom(src => src.Tasks!.Select(t => t.TaskId))
			);
	}
}
