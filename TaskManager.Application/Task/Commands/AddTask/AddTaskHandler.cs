using MediatR;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.Task.Commands.AddTask;

public class AddTaskHandler : IRequestHandler<AddTaskCommand, string>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public AddTaskHandler(
        ITaskRepository taskRepository,
        IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<string> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var project = await _projectRepository.Get(dto.ProjectId);

        if (project is null)
            throw new InvalidOperationException("Project does not exist.");

        if (project.Participants.All(p => p.UserId != dto.AssigneeId))
            throw new InvalidOperationException("Assignee does not belong to the project.");

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