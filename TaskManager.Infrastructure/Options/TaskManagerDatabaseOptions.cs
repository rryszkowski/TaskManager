namespace TaskManager.Infrastructure.Options;

public sealed class TaskManagerDatabaseOptions
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}