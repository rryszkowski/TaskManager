using TaskManager.Domain.Enums;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Entities;

public sealed class Project : Entity
{
    public Project(
        string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        string ownerId)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        OwnerId = ownerId;
        Participants = new List<Participant>();

        AddParticipant(Participant.Create(ownerId, ProjectRole.Owner));
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string OwnerId { get; private set; }
    public IList<Participant> Participants { get; private set; }

    public void AddParticipant(Participant participant) =>
        Participants.Add(participant);
}