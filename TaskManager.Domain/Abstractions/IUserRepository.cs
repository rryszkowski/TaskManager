using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Abstractions;

public interface IUserRepository : IRepository<User>
{
    Task<string?> GetUserIdByUsername(string username);
}