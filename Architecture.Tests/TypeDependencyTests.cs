using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class TypeDependencyTests
{
    [Fact]
    public void Handlers_should_have_dependency_on_Domain()
    {
        // Arrange
        var applicationAssembly = typeof(TaskManager.Application.AssemblyReference).Assembly;

        // Act
        var result = Types
            .InAssembly(applicationAssembly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(ProjectNames.Domain)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}