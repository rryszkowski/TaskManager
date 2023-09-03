using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(
        IMongoDatabase mongoDatabase)
        : base(mongoDatabase.GetCollection<Comment>("Comments"))
    {
    }
}