using MediatR;

namespace TaskManager.Application.Task.Commands.AddTag;

public record AddTagCommand(string TaskId, string Tag) : IRequest;