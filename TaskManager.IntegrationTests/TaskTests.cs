using FluentAssertions;
using MongoDB.Bson;
using TaskManager.Application.Project.Commands.AddProject;
using TaskManager.Application.Task.Commands.AddTask;
using TaskManager.Application.User.Commands.AddUser;
using TaskManager.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.IntegrationTests;

public class TaskTests : BaseIntegrationTest
{
    public TaskTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Create_should_add_new_task_to_database()
    {
        // Arrange
        const string title = "TestTitle";

        var userId = await Sender.Send(
            new AddUserCommand(new AddUserRequest("jdoe", "Jdoed123!", "jdoe@fakemail.com", "John", "Doe")));

        var projectId =
            await Sender.Send(new AddProjectCommand(new AddProjectRequest("test", "test", DateTime.Now,
                DateTime.Today.AddDays(2), "jdoe", null)));

        var addTaskCommand = new AddTaskCommand(
            new AddTaskRequest(title, "Test desc", "High", DateTime.Today, projectId, userId, null, null));

        // Act
        var taskId = await Sender.Send(addTaskCommand);

        // Assert
        var task = await TasksRepository.Get(taskId);

        Assert.NotNull(task);
        task.Title.Should().Be(title);
    }
}