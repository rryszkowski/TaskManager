using MediatR;

namespace TaskManager.Application.Project.Queries;

public sealed record GetAllProjectsQuery : IRequest<IEnumerable<ProjectResponse>>;