using MediatR;

namespace TaskManager.Application.Task.Commands.MarkTaskCompleted;

public sealed record MarkTaskCompletedCommand(string Id) : IRequest;