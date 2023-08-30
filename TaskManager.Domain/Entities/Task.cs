using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class Task
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority { get; set; }

    public DateTime DueDate { get; set; }

    public bool IsCompleted { get; set; }

    public void MarkAsCompleted()
        => IsCompleted = true;
}