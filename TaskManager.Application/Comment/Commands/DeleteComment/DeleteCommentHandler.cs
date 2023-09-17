using MediatR;
using TaskManager.Application.Comment.Commands.EditComment;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Comment.Commands.DeleteComment;

public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand>
{
    private readonly ICommentRepository _commentRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public DeleteCommentHandler(
        ICommentRepository commentRepository,
        ITaskRepository taskRepository,
        IProjectRepository projectRepository)
    {
        _commentRepository = commentRepository;
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }
    
    public async System.Threading.Tasks.Task Handle(
        DeleteCommentCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var comment = await _commentRepository.Get(dto.CommentId);

        if (comment is null)
            throw new InvalidOperationException("Comment does not exist.");

        var task = await _taskRepository.Get(comment.TaskId);

        if (task is null)
            throw new InvalidOperationException("Task does not exist.");

        var project = await _projectRepository.Get(task.ProjectId);

        if (project is null)
            throw new InvalidOperationException("Project does not exist.");

        var owner = project.Participants.Single(p => p.Role == ProjectRole.Owner);

        if (comment.UserId != dto.UserId && owner.UserId != dto.UserId)
            throw new InvalidOperationException("Only author of the comment or project owner can delete the comment.");

        await _commentRepository.Delete(dto.CommentId);
    }
}