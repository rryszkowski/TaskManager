using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Entities;

public class Task
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TaskPriority TaskPriority { get; set; }

    public DateTime DueDate { get; set; }

    public  TaskStatus Status { get; set; }

    public void MarkAsCompleted()
        => Status = TaskStatus.Completed;
}