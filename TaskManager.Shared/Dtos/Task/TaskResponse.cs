﻿using Microsoft.VisualBasic.CompilerServices;

namespace TaskManager.Shared.Dtos.Task;

public sealed record TaskResponse(string Id, string Title, string Description, string DueDate, bool IsCompleted);