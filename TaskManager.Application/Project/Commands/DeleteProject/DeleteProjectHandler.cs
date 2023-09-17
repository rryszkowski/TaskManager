using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Project.Commands.DeleteProject;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskRepository _taskRepository;

    public DeleteProjectHandler(
        IProjectRepository projectRepository,
        ITaskRepository taskRepository)
    {
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task Handle(
        DeleteProjectCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var project = await _projectRepository.Get(dto.ProjectId);

        if (project is null)
            throw new InvalidOperationException("Project does not exist.");

        if (project.OwnerId != dto.UserId)
            throw new InvalidOperationException("Project can be only deleted by its owner.");
        
        await _taskRepository.DeleteRange(t => t.ProjectId == dto.ProjectId);
        await _projectRepository.Delete(dto.ProjectId);
    }
}