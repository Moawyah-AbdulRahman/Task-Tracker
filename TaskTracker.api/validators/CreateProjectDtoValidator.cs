using FluentValidation;
using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
{
    private readonly ITeamRepository teamRepository;

    public CreateProjectDtoValidator(ITeamRepository teamRepository)
    {
        this.teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));

        RuleFor(p => p.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name));
    }
}