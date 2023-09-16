using MediatR;

namespace TaskManager.Application.Task.Commands.ChangeTaskStatus;

public record ChangeTaskStatusCommand(string TaskId, string Status) : IRequest;