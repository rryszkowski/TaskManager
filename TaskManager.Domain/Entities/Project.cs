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
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string OwnerId { get; private set; }
}