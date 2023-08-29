using MediatR;
using TaskManager.Domain.Abstractions;
using TaskManager.Shared.Dtos.Task;

namespace TaskManager.Application.Task.Queries.GetAllTasks;

public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskResponse>>
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTasksHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskResponse>> Handle(
        GetAllTasksQuery request,
        CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAll();

        return tasks.Select(t => new TaskResponse(t.Id, t.Title, t.Description, $"{t.DueDate}", t.IsCompleted));
    }
}