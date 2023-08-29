using MediatR;
using TaskManager.Shared.Dtos.Task;

namespace TaskManager.Application.Task.Queries.GetAllTasks;

public sealed record GetAllTasksQuery : IRequest<IEnumerable<TaskResponse>>;