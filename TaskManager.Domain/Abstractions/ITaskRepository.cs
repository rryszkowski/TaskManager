namespace TaskManager.Domain.Abstractions;

public interface ITaskRepository
{
    Task<string> Create(Entities.Task task);
    Task<Entities.Task> Get(string id);
    Task<IEnumerable<Entities.Task>> GetAll();
    Task Update(Entities.Task task);
    Task Delete(string id);
}