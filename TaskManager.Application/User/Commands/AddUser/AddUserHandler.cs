using MediatR;
using System.Text.RegularExpressions;
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

        if (!IsValidPassword(dto.Password))
            throw new InvalidOperationException("Password policy not met.");

        var user = new Domain.Entities.User(
            dto.Username,
            dto.Password,
            dto.Email,
            dto.FirstName,
            dto.LastName);

        return await _userRepository.Create(user);
    }

    private static bool IsValidPassword(string password)
    {
        // At least one upper case letter, one lower case letter, one digit, one special character
        // and at least 8 characters long
        const string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        return Regex.IsMatch(password, pattern);
    }
}