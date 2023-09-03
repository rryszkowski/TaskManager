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

    public async Task<string> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var taskEntity = new Domain.Entities.Task(
            dto.Title,
            dto.Description,
            Enum.Parse<TaskPriority>(dto.Priority),
            dto.DueDate,
            TaskStatus.ToDo,
            dto.ProjectId,
            dto.AssigneeId,
            dto.Tags);

        return await _taskRepository.Create(taskEntity);
    }
}