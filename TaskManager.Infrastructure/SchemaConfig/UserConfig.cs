using MongoDB.Driver;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.SchemaConfig;

public static class UserConfig
{
    public static void ConfigureUsers(IMongoDatabase db)
    {
        var uniqueOption = new CreateIndexOptions { Unique = true };
        
        var emailUnique = Builders<User>.IndexKeys.Ascending(user => user.Email);
        var emailUniqueModel = new CreateIndexModel<User>(emailUnique, uniqueOption);

        var usernameUnique = Builders<User>.IndexKeys.Ascending(user => user.Username);
        var usernameUniqueModel = new CreateIndexModel<User>(usernameUnique, uniqueOption);

        var collection = db.GetCollection<User>("Users");
        collection.Indexes.CreateMany(new[] { emailUniqueModel, usernameUniqueModel });
    }
}