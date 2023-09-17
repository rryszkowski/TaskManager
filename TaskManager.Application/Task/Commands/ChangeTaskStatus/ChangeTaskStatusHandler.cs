using MediatR;
using TaskManager.Domain.Abstractions;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

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

        if (newStatus == TaskStatus.Completed)
        {
            var dependentTasks = (await _taskRepository.Find(t => t.ParentTaskId == task.Id)).ToList();

            if (dependentTasks.Any() && !dependentTasks.All(dt => dt.Status is TaskStatus.Completed))
                throw new InvalidOperationException("Not all dependent tasks are in Completed status.");
        }

        task.ChangeStatus(newStatus);
        
        if (cancellationToken.IsCancellationRequested)
            return;

        await _taskRepository.Update(task);
    }
}