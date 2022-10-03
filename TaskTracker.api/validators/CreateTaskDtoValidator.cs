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
                userId => userId is null || userRepository.HasId(userId.Value)
            );

        RuleFor(t => t.StoryPointsValue)
            .Must(
                storyPoints =>
                    storyPoints is null ||
                    taskRepository.StoryPointsValueAvailable(storyPoints.Value)
            );

        RuleFor(t => t.State)
            .Must(
                (task, state) =>
                    (state == TaskState.ToDo) ||
                    (task.SprintName is not null &&
                        task.Assignee is not null &&
                        task.StoryPointsValue is not null)
            );
    }
}