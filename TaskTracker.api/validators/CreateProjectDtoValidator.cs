using FluentValidation;
using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
{
    private readonly IUserRepository userRepository;

    public CreateProjectDtoValidator(IUserRepository userRepository)
    {
        this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        
        RuleFor(p => p.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name));
        RuleFor(p => p.OwnerId)
            .Must(id => userRepository.HasId(id));
    }
}