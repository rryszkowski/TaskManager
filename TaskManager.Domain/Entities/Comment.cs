namespace TaskManager.Domain.Entities;

public class Comment : Entity
{
    public string Text { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public string TaskId { get; set; } = null!;
    public string UserId { get; set; } = null!;
}