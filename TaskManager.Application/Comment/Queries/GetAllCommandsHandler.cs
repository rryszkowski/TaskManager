using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Comment.Queries;

public class GetAllCommandsHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<CommentResponse>>
{
    private readonly ICommentRepository _commentRepository;

    public GetAllCommandsHandler(
        ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<CommentResponse>> Handle(
        GetAllCommentsQuery request,
        CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetAll();

        return comments.Select(c => new CommentResponse(
            c.Id,
            c.Text,
            c.Timestamp,
            c.UserId,
            c.TaskId));
    }
}