using FluentValidation;
using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
{
    public CreateTaskDtoValidator(IUserRepository userRepository, ITaskRepository taskRepository)
    {
        RuleFor(t => t.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name));

        RuleFor(t => t.Assignee)
            .Must(
                userId => userRepository.HasId(userId)
            );

        RuleFor(t => t.StoryPointsValue)
            .Must(
                value => taskRepository.StoryPointsValueAvailable(value)
            );
    }
}