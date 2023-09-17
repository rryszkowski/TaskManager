namespace TaskManager.Domain.Entities;

public sealed class Comment : Entity
{
    public Comment(
        string text,
        DateTime timestamp,
        string taskId,
        string userId)
    {
        Text = text;
        Timestamp = timestamp;
        TaskId = taskId;
        UserId = userId;
    }

    public string Text { get; set; }
    public DateTime Timestamp { get; set; }
    public string TaskId { get; private set; }
    public string UserId { get; private set; }
}