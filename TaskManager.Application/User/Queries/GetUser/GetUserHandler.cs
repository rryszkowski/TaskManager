using MediatR;
using TaskManager.Application.User.Queries.GetAllUsers;
using TaskManager.Domain.Abstractions;

namespace TaskManager.Application.User.Queries.GetUser;

public class GetUserHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(
        GetUserQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id);

        return new UserResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Username,
            user.Password,
            user.Email);
    }
}