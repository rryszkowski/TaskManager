using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Task.Commands.AddTag;
using TaskManager.Application.Task.Commands.AddTask;
using TaskManager.Application.Task.Commands.ChangeTaskStatus;
using TaskManager.Application.Task.Commands.DeleteTask;
using TaskManager.Application.Task.Commands.MarkTaskCompleted;
using TaskManager.Application.Task.Queries.GetAllTasks;

namespace TaskManager.Presentation.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ISender _sender;

    public TaskController(
        ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddTaskRequest request)
    {
        var command = new AddTaskCommand(request);

        return Ok(await _sender.Send(command));
    }

    [HttpPatch("{id}/completed")]
    public async Task<ActionResult> MarkAsCompleted(string id)
    {
        var command = new MarkTaskCompletedCommand(id);

        await _sender.Send(command);

        return Ok();
    }

    [HttpPatch("{id}/changestatus/{status}")]
    public async Task<ActionResult> ChangeTaskStatus(
        string id,
        string status,
        CancellationToken cancellationToken)
    {
        var command = new ChangeTaskStatusCommand(id, status);

        await _sender.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPatch("{id}/addtag/{tag}")]
    public async Task<ActionResult> AddTag(string id, string tag)
    {
        var command = new AddTagCommand(id, tag);

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