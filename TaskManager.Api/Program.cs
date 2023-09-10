using System.Reflection;
using System.Text.Json.Serialization;
using TaskManager.Infrastructure.Extensions;
using TaskManager.Infrastructure.Maps;
using TaskManager.Infrastructure.Options;

MongoMaps.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TaskManagerDatabaseOptions>(
    builder.Configuration.GetSection("TaskManagerDatabase"));

builder.Services.RegisterInfrastructure();

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
    .AddApplicationPart(typeof(TaskManager.Presentation.AssemblyReference).Assembly); // Indicates where the controllers are

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("TaskManager.Application")));

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

public partial class Program{}