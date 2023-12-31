﻿namespace TaskManager.Application.Project.Queries;

public sealed record ProjectResponse(string Id, string Name, string Description, DateTime StartDate, DateTime EndDate, IEnumerable<ParticipantResponse> Participants);