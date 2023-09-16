using MediatR;
using TaskManager.Domain.Abstractions;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.Task.Commands.MarkTaskCompleted;

public class MarkTaskCompletedHandler : IRequestHandler<MarkTaskCompletedCommand>
{
    private readonly ITaskRepository _taskRepository;

    public MarkTaskCompletedHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task Handle(
        MarkTaskCompletedCommand request,
        CancellationToken cancellationToken)
    {
        var task = await _taskRepository.Get(request.Id);

        if (task is null)
            throw new InvalidOperationException("Task does not exist.");

        task.ChangeStatus(TaskStatus.Completed);
        await _taskRepository.Update(task);
    }
}