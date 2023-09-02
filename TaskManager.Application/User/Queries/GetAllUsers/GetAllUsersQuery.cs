using MediatR;

namespace TaskManager.Application.User.Queries.GetAllUsers;

public sealed record GetAllUsersQuery() : IRequest<IEnumerable<UserResponse>>;