using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskManager.Infrastructure.Options;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Infrastructure.SchemaConfig;

namespace TaskManager.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterInfrastructure(this IServiceCollection services)
    {
        services
            .ConfigureMongo()
            .ConfigureRepositories();
    }

    private static IServiceCollection ConfigureMongo(this IServiceCollection services)
    {
        services.AddSingleton(sp =>
        {
            var dbOptions = sp.GetService<IOptions<TaskManagerDatabaseOptions>>();
            var mongoClient = new MongoClient(dbOptions!.Value.ConnectionString);
            var db = mongoClient.GetDatabase(dbOptions.Value.DatabaseName);

            UserConfig.ConfigureUsers(db);

            return db;
        });

        return services;
    }

    private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ITaskRepository, TaskRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IProjectRepository, ProjectRepository>();
        services.AddSingleton<ICommentRepository, CommentRepository>();

        return services;
    }
}