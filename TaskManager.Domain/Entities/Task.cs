using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Entities;

public class Task : Entity
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public TaskPriority TaskPriority { get; set; }

    public DateTime DueDate { get; set; }

    public  TaskStatus Status { get; set; }

    public void MarkAsCompleted()
        => Status = TaskStatus.Completed;
}