using MediatR;

namespace TaskManager.Application.Comment.Commands.AddComment;

public sealed record AddCommentCommand(AddCommentRequest Dto) : IRequest<string>;