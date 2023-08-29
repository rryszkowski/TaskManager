using System.Reflection;
using TaskManager.Domain.Abstractions;
using TaskManager.Infrastructure.Extensions;
using TaskManager.Infrastructure.Maps;
using TaskManager.Infrastructure.Options;
using TaskManager.Infrastructure.Repositories;

MongoMaps.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TaskManagerDatabaseOptions>(
    builder.Configuration.GetSection("TaskManagerDatabase"));

builder.Services.ConfigureMongo();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("TaskManager.Application")));

builder.Services.AddSingleton<ITaskRepository, TaskRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
