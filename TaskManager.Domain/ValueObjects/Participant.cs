using TaskManager.Domain.Enums;

namespace TaskManager.Domain.ValueObjects;

public class Participant
{
    private Participant(
        string userId,
        ProjectRole role)
    {
        UserId = userId;
        Role = role;
    }

    public string UserId { get; private init; }
    public ProjectRole Role { get; private init; }

    public static Participant Create(string userId, ProjectRole role) => new(userId, role);
}