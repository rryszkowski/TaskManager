using MediatR;

namespace TaskManager.Application.Comment.Queries;

public sealed record GetAllCommentsQuery : IRequest<IEnumerable<CommentResponse>>;