using MediatR;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Entities;
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

        var taskEntity = new Domain.Entities.Task
        {
            Description = dto.Description,
            TaskPriority = Enum.Parse<TaskPriority>(dto.Priority),
            DueDate = dto.DueDate,
            Title = dto.Title,
            Status = TaskStatus.ToDo,
            ProjectId = dto.ProjectId,
            AssigneeId = dto.AssigneeId
        };

        if (dto.Tags != null && dto.Tags.Any())
            taskEntity.Tags.AddRange(dto.Tags);

        return await _taskRepository.Create(taskEntity);
    }
}