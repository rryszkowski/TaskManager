using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class AssemblyDependencyTests
{
    [Fact]
    public void Domain_should_not_have_dependencies_on_other_projects()
    {
        // Arrange
        var assembly = typeof(TaskManager.Domain.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ProjectNames.Api,
            ProjectNames.Application,
            ProjectNames.Infrastructure,
            ProjectNames.Shared
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_should_not_have_dependencies_on_other_projects()
    {
        // Arrange
        var assembly = typeof(TaskManager.Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ProjectNames.Api,
            ProjectNames.Infrastructure
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_should_not_have_dependencies_on_other_projects()
    {
        // Arrange
        var assembly = typeof(TaskManager.Infrastructure.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ProjectNames.Api,
            ProjectNames.Application
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Shared_should_not_have_dependencies_on_other_projects()
    {
        // Arrange
        var assembly = typeof(TaskManager.Shared.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ProjectNames.Api,
            ProjectNames.Application,
            ProjectNames.Domain,
            ProjectNames.Infrastructure
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}