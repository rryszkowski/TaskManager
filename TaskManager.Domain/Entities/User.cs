namespace TaskManager.Domain.Entities;

public sealed class User : Entity
{
    public User(
        string username,
        string password,
        string email,
        string firstName,
        string lastName)
    {
        Username = username;
        Password = password;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}