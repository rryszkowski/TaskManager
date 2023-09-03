using TaskManager.Application.Task.Commands.AddTag;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Task.Commands.AddTask;

public sealed record AddTaskRequest(
    string Title,
    string Description,
    string Priority,
    DateTime DueDate,
    string ProjectId,
    string? AssigneeId,
    IReadOnlyList<string>? Tags);
