using TaskManager.Domain.Enums;

namespace TaskManager.Application.Project.Queries;

public sealed record ParticipantResponse(string Username, ProjectRole Role);