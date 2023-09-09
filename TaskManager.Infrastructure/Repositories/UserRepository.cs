using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IMongoCollection<User> _userCollection;

    public UserRepository(
        IMongoDatabase mongoDatabase)
        : base(mongoDatabase.GetCollection<User>("Users"))
    {
        _userCollection = mongoDatabase.GetCollection<User>("Users");
    }

    public async Task<string?> GetUserIdByUsername(string username)
        => (await _userCollection.FindAsync(u => u.Username == username))
            .FirstOrDefault()?.Id;
}