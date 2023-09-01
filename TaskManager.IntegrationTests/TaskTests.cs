using FluentAssertions;
using TaskManager.Application.Task.Commands.AddTask;

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

        var command = new AddTaskCommand(
            new AddTaskRequest(title, "Test desc", "High", DateTime.Today));

        // Act
        var taskId = await Sender.Send(command);

        // Assert
        var task = await TasksRepository.Get(taskId);

        Assert.NotNull(task);
        task.Title.Should().Be(title);
    }
}