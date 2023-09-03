using MediatR;

namespace TaskManager.Application.Project.Commands.AddProject;

public record AddProjectCommand(AddProjectRequest Dto) : IRequest<string>;