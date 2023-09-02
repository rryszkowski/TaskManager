using MediatR;

namespace TaskManager.Application.Task.Queries.GetAllTasks;

public sealed record GetAllTasksQuery : IRequest<IEnumerable<TaskResponse>>;