using MediatR;

namespace TaskManager.Application.Task.Commands.AddTask;

public record AddTaskCommand(AddTaskRequest Dto) : IRequest<string>;