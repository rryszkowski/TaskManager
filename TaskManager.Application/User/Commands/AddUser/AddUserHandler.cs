using MediatR;
using TaskManager.Domain.Abstractions;
using SystemTask = System.Threading.Tasks.Task;

namespace TaskManager.Application.User.Commands.AddUser;

public class AddUserHandler : IRequestHandler<AddUserCommand, string>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(
        AddUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User
        {
            FirstName = request.Dto.FirstName,
            LastName = request.Dto.LastName,
            Email = request.Dto.Email,
            Username = request.Dto.Username,
            Password = request.Dto.Password
        };

        return await _userRepository.Create(user);
    }
}