﻿using MongoDB.Driver;
using TaskManager.Domain.Abstractions;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(
        IMongoDatabase mongoDatabase)
        : base(mongoDatabase.GetCollection<User>("Users"))
    {
    }
}