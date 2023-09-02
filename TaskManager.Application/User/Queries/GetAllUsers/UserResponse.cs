namespace TaskManager.Application.User.Queries.GetAllUsers;

public sealed record UserResponse(
    string Id,
    string FirstName,
    string LastName,
    string Username,
    string Password,
    string Email);