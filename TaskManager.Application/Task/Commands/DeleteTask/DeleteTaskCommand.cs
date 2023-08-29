using MediatR;

namespace TaskManager.Application.Task.Commands.DeleteTask;

public record DeleteTaskCommand(string Id) : IRequest;