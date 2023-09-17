namespace TaskManager.Application.Comment.Commands.AddComment;

public sealed record AddCommentRequest(
    string Text,
    DateTime Timestamp,
    string TaskId,
    string UserId);