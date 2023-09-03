namespace TaskManager.Application.Project.Queries;

public sealed record ProjectResponse(string Name, string Description, DateTime StartDate, DateTime EndDate, string Owner);