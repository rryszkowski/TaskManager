namespace TaskManager.Application.Project.Commands.AddProject;

public sealed record AddProjectRequest(string Name, string Description, DateTime StartDate, DateTime EndDate, string Owner);