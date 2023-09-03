using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskEntity = TaskManager.Domain.Entities.Task;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository : Repository<TaskEntity>, ITaskRepository
{
    public TaskRepository(
        IMongoDatabase mongoDatabase)
        : base(mongoDatabase.GetCollection<TaskEntity>("Tasks"))
    {
    }
}