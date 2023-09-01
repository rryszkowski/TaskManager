using MediatR;

namespace TaskManager.Application.Task.Commands.AddTask;

public record AddTaskCommand(AddTaskRequest Request) : IRequest<string>;