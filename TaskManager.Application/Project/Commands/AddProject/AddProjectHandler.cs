using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Project.Commands.AddProject;

public class AddProjectHandler : IRequestHandler<AddProjectCommand, string>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public AddProjectHandler(
        IProjectRepository projectRepository,
        IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(
        AddProjectCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var ownerId = await _userRepository
            .GetUserIdByUsername(dto.Owner);

        if (ownerId is null)
            throw new InvalidOperationException("Owner not found");

        var projectId = await _projectRepository.Create(
            new Domain.Entities.Project(
                dto.Name,
                dto.Description,
                dto.StartDate,
                dto.EndDate,
                ownerId));

        return projectId;
    }
}