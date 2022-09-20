
using AutoMapper;
using TaskTracker.Db;

namespace TaskTracker.api;

public class TeamProfile : Profile
{
    private readonly IUserRepository userRepository;

    public TeamProfile(IUserRepository userRepository)
    {
        this.userRepository = userRepository
            ?? throw new ArgumentNullException(nameof(userRepository));

        CreateMap<CreateTeamDto, Team>()
            .ForMember(
                dest => dest.Members,
                opt => opt.MapFrom(src => userRepository.GetUsers(src.MemberIds))
            );

        CreateMap<Team, TeamDto>()
            .ForMember(
                dest => dest.MemberIds,
                opt => opt.MapFrom(
                    src => src.Members!.Select(u => u.UserID).ToList()
                        ?? new List<long>()
                    )
            );
    }
}
