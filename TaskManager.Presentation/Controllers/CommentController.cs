using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Comment.Commands.AddComment;
using TaskManager.Application.Comment.Commands.EditComment;
using TaskManager.Application.Comment.Queries;
using TaskManager.Application.Project.Commands.AddParticipant;

namespace TaskManager.Presentation.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ISender _sender;

    public CommentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddCommentRequest request)
    {
        var command = new AddCommentCommand(request);

        return Ok(await _sender.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var tasks = await _sender.Send(new GetAllCommentsQuery());

        return Ok(tasks);
    }

    [HttpPatch]
    public async Task<ActionResult> EditComment([FromBody] EditCommentRequest request)
    {
        var command = new EditCommentCommand(request);

        await _sender.Send(command);

        return Ok();
    }
}