using MediatR;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.User.Queries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserResponse>> Handle(
        GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll();

        return users.Select(u => new UserResponse(
            u.Id,
            u.FirstName,
            u.LastName,
            u.Username,
            u.Password,
            u.Email));
    }
}