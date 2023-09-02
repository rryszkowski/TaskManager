using MediatR;
using TaskManager.Application.User.Queries.GetAllUsers;

namespace TaskManager.Application.User.Queries.GetUser;

public record GetUserQuery(string Id) : IRequest<UserResponse>;