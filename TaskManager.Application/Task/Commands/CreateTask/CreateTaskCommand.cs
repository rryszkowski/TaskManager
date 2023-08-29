using MediatR;
using TaskManager.Shared.Dtos.Task;

namespace TaskManager.Application.Task.Commands.CreateTask;

public record CreateTaskCommand(CreateTaskRequest Request) : IRequest;