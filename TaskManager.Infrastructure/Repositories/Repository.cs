﻿using System.Linq.Expressions;
using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Base;
using TaskManager.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.Infrastructure.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    private readonly IMongoCollection<TEntity> _collection;

    protected Repository(
        IMongoCollection<TEntity> collection)
    {
        _collection = collection;
    }

    public async Task<string> Create(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);

        return entity.Id;
    }

    public async Task<TEntity?> Get(string id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<TEntity>> GetAll()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task Update(TEntity entity)
        => await _collection.ReplaceOneAsync(t => t.Id == entity.Id, entity);

    public async Task Delete(string id)
        => await _collection.DeleteOneAsync(t => t.Id == id);

    public async Task DeleteRange(Expression<Func<TEntity, bool>> predicate)
        => await _collection.DeleteManyAsync(predicate);

    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        => (await _collection.FindAsync(predicate)).ToEnumerable();
}