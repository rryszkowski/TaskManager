using MediatR;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.Task.Commands.AddTask;

public class AddTaskHandler : IRequestHandler<AddTaskCommand, string>
{
    private readonly ITaskRepository _taskRepository;

    public AddTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task<string> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var taskEntity = new Domain.Entities.Task
        {
            Description = request.Request.Description,
            TaskPriority = Enum.Parse<TaskPriority>(request.Request.Priority),
            DueDate = request.Request.DueDate,
            Title = request.Request.Title,
            Status = TaskStatus.ToDo
        };

        return await _taskRepository.Create(taskEntity);
    }
}