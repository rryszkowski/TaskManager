using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Task.Commands.AddTag;

public class AddTagHandler : IRequestHandler<AddTagCommand>
{
    private readonly ITaskRepository _taskRepository;

    public AddTagHandler(
        ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task Handle(
        AddTagCommand request,
        CancellationToken cancellationToken)
    {
        var task = await _taskRepository.Get(request.TaskId);

        if (task is null)
            return;

        if (task.Tags.All(t => t != request.Tag))
            task.Tags.Add(request.Tag);

        await _taskRepository.Update(task);
    }
}