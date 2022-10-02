using FluentValidation;
using TaskTracker.Db;

namespace TaskTracker.api;

public class CreateSprintDtoValidator : AbstractValidator<CreateSprintDto>
{
    public CreateSprintDtoValidator(ITaskRepository taskRepository, ITeamRepository teamRepository,
            ISprintRepository sprintRepository)
    {
        RuleFor(s => s.SprintName)
            .Must(n => !string.IsNullOrEmpty(n))
            .Must(n => !sprintRepository.HasName(n));
        
        RuleFor(s => s.TeamId)
            .Must(id => teamRepository.HasId(id));

        RuleFor(s => s.TaskIds)
            .Must(ids => ids?.All(id => taskRepository.HasId(id)) ?? true)
            .Must(
            (sprint, ids) =>
                !sprint.ShouldStartSprint ||
                taskRepository.GetTasks(ids ?? Enumerable.Empty<long>())
                    .Aggregate(0, (sum, task) => sum + task.StoryPointsValue) >= 50
                );
    }
}
