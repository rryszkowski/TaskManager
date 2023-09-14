using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.Project.Queries;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectResponse>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public GetAllProjectsHandler(
        IProjectRepository projectRepository,
        IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<ProjectResponse>> Handle(
        GetAllProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var projects = (await _projectRepository.GetAll()).ToList();
        
        var logins = (await _userRepository.GetAll())
            .ToDictionary(k => k.Id, v => v.Username);

        var projectsResponses = projects.Select(p =>
            new ProjectResponse(
                p.Id,
                p.Name,
                p.Description,
                p.StartDate,
                p.EndDate,
                new List<ParticipantResponse>(p.Participants.Select(par =>
                    new ParticipantResponse(GetLogin(par.UserId)!, par.Role)))));

        return projectsResponses;

        string? GetLogin(string userId)
            => logins.TryGetValue(userId, out var login) 
                ? login 
                : null;
    }
}