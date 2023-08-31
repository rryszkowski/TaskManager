﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Task.Commands.CreateTask;
using TaskManager.Application.Task.Commands.DeleteTask;
using TaskManager.Application.Task.Commands.MarkTaskCompleted;
using TaskManager.Application.Task.Queries.GetAllTasks;

namespace TaskManager.Api.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public TaskController(
        ISender sender,
        IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateTaskRequest request)
    {
        var command = new CreateTaskCommand(request);

        return Ok(await _sender.Send(command));
    }

    [HttpPatch("{id}/completed")]
    public async Task<ActionResult> MarkAsCompleted(string id)
    {
        var command = new MarkTaskCompletedCommand(id);

        await _sender.Send(command);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var tasks = await _sender.Send(new GetAllTasksQuery());
        
        return Ok(tasks);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(string id)
    {
        await _sender.Send(new DeleteTaskCommand(id));

        return NoContent();
    }
}