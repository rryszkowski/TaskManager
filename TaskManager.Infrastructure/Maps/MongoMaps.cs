using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using TaskManager.Domain.Base;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Infrastructure.Maps;

public static class MongoMaps
{
    public static void Configure()
    {
        ConfigureEntity();
        ConfigureProject();
        ConfigureTask();
        ConfigureUser();
    }

    private static void ConfigureEntity()
    {
        BsonClassMap.RegisterClassMap<Entity>(map =>
        {
            map.MapIdField(m => m.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });
    }

    private static void ConfigureProject()
    {
        BsonClassMap.RegisterClassMap<Project>(map =>
        {
            map.AutoMap();
            map.SetIgnoreExtraElements(true);
            map.MapField(f => f.Participants);
        });
    }

    private static void ConfigureTask()
    {
        BsonClassMap.RegisterClassMap<Task>(map =>
        {
            map.AutoMap();
            map.SetIgnoreExtraElements(true);
            map.MapField(f => f.Tags);
        });
    }

    private static void ConfigureUser()
    {
        BsonClassMap.RegisterClassMap<User>(map =>
        {
            map.AutoMap();
            map.SetIgnoreExtraElements(true);
        });
    }
}