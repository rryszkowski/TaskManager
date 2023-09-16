using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Project.Commands.AddParticipant;
using TaskManager.Application.Project.Commands.AddProject;
using TaskManager.Application.Project.Queries;

namespace TaskManager.Presentation.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddProjectRequest request)
    {
        var command = new AddProjectCommand(request);
        
        return Ok(await _sender.Send(command));
    }

    [HttpPatch("{id}/addparticipant/{userId}")]
    public async Task<ActionResult> AddParticipant(string id, string userId)
    {
        var command = new AddParticipantCommand(id, userId);

        await _sender.Send(command);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var tasks = await _sender.Send(new GetAllProjectsQuery());

        return Ok(tasks);
    }
}