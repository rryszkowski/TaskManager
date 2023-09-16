using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Task.Commands.ChangeTaskStatus;

public class ChangeTaskStatusHandler : IRequestHandler<ChangeTaskStatusCommand>
{
    private readonly ITaskRepository _taskRepository;

    public ChangeTaskStatusHandler(
        ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task Handle(
        ChangeTaskStatusCommand request,
        CancellationToken cancellationToken)
    {
        var task = await _taskRepository.Get(request.TaskId);

        if (task is null)
            throw new InvalidOperationException("Task does not exist.");

        Enum.TryParse<Domain.Enums.TaskStatus>(request.Status, out var newStatus);

        task.ChangeStatus(newStatus);
        await _taskRepository.Update(task);
    }
}