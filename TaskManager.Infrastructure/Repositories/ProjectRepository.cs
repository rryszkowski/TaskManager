using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(
        IMongoDatabase mongoDatabase)
        : base(mongoDatabase.GetCollection<Project>("Projects"))
    {
    }
}