using MediatR;

namespace TaskManager.Application.Comment.Commands;

public sealed record AddCommentCommand(AddCommentRequest Dto) : IRequest<string>;