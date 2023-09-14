using MediatR;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Enums;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Application.Project.Commands.AddParticipant;

public class AddParticipantHandler : IRequestHandler<AddParticipantCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;

    public AddParticipantHandler(
        IUserRepository userRepository,
        IProjectRepository projectRepository)
    {
        _userRepository = userRepository;
        _projectRepository = projectRepository;
    }

    public async System.Threading.Tasks.Task Handle(
        AddParticipantCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .Get(request.UserId);

        if (user is null)
            throw new InvalidOperationException("User not found.");

        var project = await _projectRepository
            .Get(request.ProjectId);

        if (project is null)
            throw new InvalidOperationException("Project not found.");

        project.AddParticipant(
            Participant.Create(request.UserId, ProjectRole.Participant));

        await _projectRepository.Update(project);
    }
}