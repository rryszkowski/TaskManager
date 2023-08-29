using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Infrastructure.Maps;

public static class MongoMaps
{
    public static void Configure()
    {
        ConfigureTask();
    }

    private static void ConfigureTask()
    {
        BsonClassMap.RegisterClassMap<Task>(map =>
        {
            map.AutoMap();
            map.MapIdField(m => m.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });
    }
}