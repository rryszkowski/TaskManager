using TaskManager.Domain.Base;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Entities;

public sealed class Task : Entity
{
    private static readonly List<(TaskStatus current, TaskStatus next)> AllowedTransitions = new()
    {
        (TaskStatus.ToDo, TaskStatus.InProgress),
        (TaskStatus.InProgress, TaskStatus.Completed),
        (TaskStatus.Completed, TaskStatus.ToDo)
    };

    public Task(
        string title,
        string description,
        TaskPriority priority,
        DateTime dueDate,
        TaskStatus status,
        string projectId,
        string? assigneeId,
        string? parentTaskId,
        IReadOnlyList<string>? tags)
    {
        Title = title;
        Description = description;
        Priority = priority;
        DueDate = dueDate;
        Status = status;
        ProjectId = projectId;
        ParentTaskId = parentTaskId;
        AssigneeId = assigneeId;

        Tags = new List<string>();
        
        if (tags != null && tags.Any())
            Tags.AddRange(tags);
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public TaskPriority Priority { get; private set; }

    public DateTime DueDate { get; private set; }

    public  TaskStatus Status { get; private set; }

    public List<string> Tags { get; private set;}

    public string ProjectId { get; private set; }
    
    public string? AssigneeId { get; private set; }
    
    public string? ParentTaskId { get; private set; }

    public void ChangeStatus(TaskStatus newStatus)
    {
        if (!AllowedTransitions.Contains((Status, newStatus)))
        {
            throw new InvalidOperationException($"Task status can't be changed from status {Status} to {newStatus}");
        }

        Status = newStatus;
    }
}