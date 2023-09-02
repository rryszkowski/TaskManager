namespace TaskManager.Domain.Abstractions;

public interface IUserRepository
{
    Task<string> Create(Entities.User user);
    Task<Entities.User> Get(string id);
    Task<IEnumerable<Entities.User>> GetAll();
    Task Update(Entities.User user);
    Task Delete(string id);
}