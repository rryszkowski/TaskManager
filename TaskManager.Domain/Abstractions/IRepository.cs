namespace TaskManager.Domain.Abstractions;

public interface IRepository<TEntity>
{
    Task<string> Create(TEntity entity);
    Task<TEntity> Get(string id);
    Task<IEnumerable<TEntity>> GetAll();
    Task Update(TEntity entity);
    Task Delete(string id);
}