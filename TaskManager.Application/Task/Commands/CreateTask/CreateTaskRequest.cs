﻿namespace TaskManager.Application.Task.Commands.CreateTask;

public sealed record CreateTaskRequest(string Title, string Description, DateTime DueDate);
