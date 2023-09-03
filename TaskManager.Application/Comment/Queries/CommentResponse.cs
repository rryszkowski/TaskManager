namespace TaskManager.Application.Comment.Queries;

public sealed record CommentResponse(
    string Id,
    string Text,
    DateTime Timestamp,
    string UserId,
    string TaskId);