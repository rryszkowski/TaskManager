using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Testcontainers.MongoDb;

namespace TaskManager.IntegrationTests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MongoDbContainer _dbContainer = new MongoDbBuilder().Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(IMongoDatabase));

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddSingleton(_ =>
            {
                var mongoClient = new MongoClient(_dbContainer.GetConnectionString());
                return mongoClient.GetDatabase("TaskManagerDb");
            });
        });
    }

    public Task InitializeAsync()
    {
        return _dbContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _dbContainer.StopAsync();
    }
}