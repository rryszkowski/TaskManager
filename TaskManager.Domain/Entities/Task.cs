using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Entities;

public class Task : Entity
{
    public Task(
        string title,
        string description,
        TaskPriority priority,
        DateTime dueDate,
        TaskStatus status,
        string projectId,
        string? assigneeId,
        IReadOnlyList<string>? tags)
    {
        Title = title;
        Description = description;
        Priority = priority;
        DueDate = dueDate;
        Status = status;
        ProjectId = projectId;
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

    public void MarkAsCompleted()
        => Status = TaskStatus.Completed;
}