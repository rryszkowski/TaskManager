using MediatR;

namespace TaskManager.Application.Comment.Commands.DeleteComment;

public sealed record DeleteCommentCommand(DeleteCommentRequest Dto) : IRequest;