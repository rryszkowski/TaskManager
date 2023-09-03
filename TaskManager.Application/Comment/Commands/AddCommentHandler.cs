using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Comment.Commands;

public class AddCommentHandler : IRequestHandler<AddCommentCommand, string>
{
    private readonly ICommentRepository _commentRepository;

    public AddCommentHandler(
        ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<string> Handle(
        AddCommentCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var comment = new Domain.Entities.Comment(
            dto.Text,
            dto.Timestamp,
            dto.TaskId,
            dto.UserId);
        

        return await _commentRepository.Create(comment);
    }
}