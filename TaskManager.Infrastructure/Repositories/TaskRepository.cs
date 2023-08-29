using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskEntity = TaskManager.Domain.Entities.Task;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly IMongoCollection<TaskEntity> _tasksCollection;

    public TaskRepository(
        IMongoDatabase mongoDatabase)
    {
        _tasksCollection = mongoDatabase.GetCollection<TaskEntity>("Tasks");
    }

    public async Task Create(TaskEntity task)
    {
        await _tasksCollection.InsertOneAsync(task);
    }

    public async Task<TaskEntity> Get(string id)
        => await _tasksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<TaskEntity>> GetAll()
        => await _tasksCollection.Find(_ => true).ToListAsync();

    public async Task Update(TaskEntity task)
        => await _tasksCollection.ReplaceOneAsync(t => t.Id == task.Id, task);

    public async Task Delete(string id)
        => await _tasksCollection.DeleteOneAsync(t => t.Id == id);
}