using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskManager.Infrastructure.Options;

namespace TaskManager.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureMongo(this IServiceCollection services)
    {
        services.AddSingleton(sp =>
        {
            var dbOptions = sp.GetService<IOptions<TaskManagerDatabaseOptions>>();
            var mongoClient = new MongoClient(dbOptions!.Value.ConnectionString);
            return mongoClient.GetDatabase(dbOptions.Value.DatabaseName);
        });
    }
}