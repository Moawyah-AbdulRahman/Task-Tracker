using FluentValidation;
using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateTeamDtoValidator : AbstractValidator<CreateTeamDto>
{
    private readonly IUserRepository userRepository;
    private readonly IProjectRepository projectRepository;

    public CreateTeamDtoValidator(IUserRepository userRepository, IProjectRepository projectRepository)
    {
        this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        this.projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        RuleFor(t => t.MemberIds)
            .Must(uIds => uIds.All(uId => userRepository.HasId(uId)));

        RuleFor(t => t.ProjectId)
            .Must(pId => projectRepository.HasId(pId));

        RuleFor(t => t.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name));

        RuleFor(t => t.TeamKeyPrefix)
            .Must(tkp => !string.IsNullOrWhiteSpace(tkp));
    }
}