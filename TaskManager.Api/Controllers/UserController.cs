using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.User.Commands.AddUser;

namespace TaskManager.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISender _sender;
    public UserController(
        ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddUserRequest request)
    {
        var command = new AddUserCommand(request);

        return Ok(await _sender.Send(command));
    }
}