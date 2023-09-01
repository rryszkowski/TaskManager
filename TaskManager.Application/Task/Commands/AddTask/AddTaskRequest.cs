﻿namespace TaskManager.Application.Task.Commands.AddTask;

public sealed record AddTaskRequest(string Title, string Description, string Priority, DateTime DueDate);
