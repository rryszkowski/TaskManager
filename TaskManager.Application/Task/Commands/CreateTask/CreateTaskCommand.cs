using MediatR;

namespace TaskManager.Application.Task.Commands.CreateTask;

public record CreateTaskCommand(CreateTaskRequest Request) : IRequest<string>;