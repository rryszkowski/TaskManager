using MediatR;

namespace TaskManager.Application.Project.Commands.AddParticipant;

public record AddParticipantCommand(string ProjectId, string UserId) : IRequest;