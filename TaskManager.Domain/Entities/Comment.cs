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

    public string Text { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string TaskId { get; private set; }
    public string UserId { get; private set; }
}