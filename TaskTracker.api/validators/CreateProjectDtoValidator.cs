using FluentValidation;

namespace TaskTracker.api;

public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
{
    public CreateProjectDtoValidator()
    {
        RuleFor(p => p.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name));
    }
}