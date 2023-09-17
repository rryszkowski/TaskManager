namespace TaskManager.Application.Task.Queries.GetAllTasks;

public sealed record TaskResponse(
    string Id,
    string Title,
    string Description,
    string Priority,
    string DueDate,
    string Status,
    string ProjectId,
    string? AssigneeId,
    string? ParentTaskId,
    IEnumerable<string> Tags);