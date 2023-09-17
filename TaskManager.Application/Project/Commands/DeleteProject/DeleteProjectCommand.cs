using MediatR;

namespace TaskManager.Application.Project.Commands.DeleteProject;

public sealed record DeleteProjectCommand(DeleteProjectRequest Dto) : IRequest;