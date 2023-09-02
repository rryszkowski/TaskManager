using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserRepository(
        IMongoDatabase mongoDatabase)
    {
        _usersCollection = mongoDatabase.GetCollection<User>("Users");
    }

    public async Task<string> Create(User user)
    {
        await _usersCollection.InsertOneAsync(user);

        return user.Id;
    }

    public async Task<User> Get(string id)
        => await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<User>> GetAll()
        => await _usersCollection.Find(_ => true).ToListAsync();

    public async Task Update(User user)
        => await _usersCollection.ReplaceOneAsync(t => t.Id == user.Id, user);

    public async Task Delete(string id)
        => await _usersCollection.DeleteOneAsync(t => t.Id == id);
}