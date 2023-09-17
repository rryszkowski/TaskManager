using MediatR;

namespace TaskManager.Application.Comment.Commands.EditComment;

public sealed record EditCommentCommand(EditCommentRequest Dto) : IRequest;