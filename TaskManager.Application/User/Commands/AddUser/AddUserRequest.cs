namespace TaskManager.Application.User.Commands.AddUser;

public sealed record AddUserRequest(
    string Username,
    string Password,
    string Email,
    string FirstName,
    string LastName);