using MediatR;
using TaskManager.Domain.Abstractions;

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
        var dto = request.Dto;

        var user = new Domain.Entities.User(
            dto.Username,
            dto.Password,
            dto.Email,
            dto.FirstName,
            dto.LastName);

        return await _userRepository.Create(user);
    }
}