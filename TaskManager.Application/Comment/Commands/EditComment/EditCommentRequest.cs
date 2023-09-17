namespace TaskManager.Application.Comment.Commands.EditComment;

public record EditCommentRequest(string CommentId, string UserId, string Text);