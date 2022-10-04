using FluentValidation;
using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
{
    private readonly IUserRepository userRepository;

    public CreateTaskDtoValidator(IUserRepository userRepository)
    {
        this.userRepository = userRepository ??
            throw new ArgumentNullException(nameof(userRepository));

        RuleFor(t => t.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name));

        RuleFor(t => t.Assignee)
            .Must(
                (user, userId) => userRepository.UserCanAccessProject(userId, user.ProjectId)
            );
    }
}