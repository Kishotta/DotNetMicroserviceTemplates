namespace Microservice.Architecture.Tests;

public class PersistenceTests
{
    [Fact]
    public void Persistence_Should_Not_HaveDependencyOnOtherProjects ()
    {
        // Arrange
        var persistenceAssembly = Persistence.AssemblyReference.Assembly;

        // Act
        var testResults = Types.InAssembly (persistenceAssembly)
                               .ShouldNot ()
                               .HaveDependencyOnAll (typeof(Api.AssemblyReference).Namespace,
                                                     typeof(Infrastructure.AssemblyReference).Namespace,
                                                     typeof(Presentation.AssemblyReference).Namespace)
                               .GetResult ();

        // Assert
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
}