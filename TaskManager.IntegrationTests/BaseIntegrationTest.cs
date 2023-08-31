using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskManager.Domain.Abstractions;

namespace TaskManager.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly ITaskRepository TasksRepository;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();

        TasksRepository = _scope.ServiceProvider.GetRequiredService<ITaskRepository>();
    }
}