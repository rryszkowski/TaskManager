using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Task.Commands.DeleteTask;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task Handle(
        DeleteTaskCommand request,
        CancellationToken cancellationToken)
    {
        await _taskRepository.Delete(request.Id);
    }
}