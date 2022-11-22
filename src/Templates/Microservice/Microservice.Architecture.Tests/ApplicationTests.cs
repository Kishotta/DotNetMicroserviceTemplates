namespace Microservice.Architecture.Tests;

public class ApplicationTests
{
    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects ()
    {
        // Arrange
        var applicationAssembly = Application.AssemblyReference.Assembly;
        
        // Act
        var testResults = Types.InAssembly (applicationAssembly)
                               .ShouldNot ()
                               .HaveDependencyOnAll (typeof(Api.AssemblyReference).Namespace,
                                                     typeof(Infrastructure.AssemblyReference).Namespace,
                                                     typeof(Persistence.AssemblyReference).Namespace,
                                                     typeof(Presentation.AssemblyReference).Namespace)
                               .GetResult ();

        // Assert
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }

    [Fact]
    public void Handlers_Should_Have_DependencyOnDomain ()
    {
        // Arrange
        var applicationAssembly = Application.AssemblyReference.Assembly;
        
        // Act
        var testResults = Types.InAssembly (applicationAssembly)
                               .That ()
                               .HaveNameEndingWith ("Handler")
                               .Should ()
                               .HaveDependencyOn (typeof(Domain.AssemblyReference).Namespace)
                               .GetResult ();
        
        // Assert
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
}