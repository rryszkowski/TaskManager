using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Task.Commands.CreateTask;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand>
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskEntity = new Domain.Entities.Task
        {
            Description = request.Request.Description,
            DueDate = request.Request.DueDate,
            Title = request.Request.Title,
            IsCompleted = false
        };

        await _taskRepository.Create(taskEntity);

        await System.Threading.Tasks.Task.CompletedTask;
    }
}