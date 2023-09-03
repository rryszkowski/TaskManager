using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Comment.Commands;
using TaskManager.Application.Comment.Queries;

namespace TaskManager.Api.Controllers;

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
}