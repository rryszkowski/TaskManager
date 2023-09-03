namespace TaskManager.Application.Comment.Commands;

public sealed record AddCommentRequest(
    string Text,
    DateTime Timestamp,
    string TaskId,
    string UserId);