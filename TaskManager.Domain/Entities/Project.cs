namespace TaskManager.Domain.Entities;

public class Project : Entity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string OwnerId { get; set; } = null!;
}