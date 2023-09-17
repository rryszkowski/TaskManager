using System.Linq.Expressions;

namespace TaskManager.Domain.Abstractions;

public interface IRepository<TEntity>
{
    Task<string> Create(TEntity entity);
    Task<TEntity?> Get(string id);
    Task<IEnumerable<TEntity>> GetAll();
    Task Update(TEntity entity);
    Task Delete(string id);
    Task DeleteRange(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
}