using MediatR;

namespace TaskManager.Application.User.Commands.AddUser;

public sealed record AddUserCommand(AddUserRequest Dto) : IRequest<string>;