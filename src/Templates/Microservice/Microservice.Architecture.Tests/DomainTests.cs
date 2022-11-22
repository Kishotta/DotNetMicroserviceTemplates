namespace Microservice.Architecture.Tests;

public class DomainTests
{
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects ()
    {
        // Arrange
        var domainAssembly = Domain.AssemblyReference.Assembly;
        
        // Act
        var testResults = Types.InAssembly (domainAssembly)
                               .ShouldNot ()
                               .HaveDependencyOnAll (typeof(Api.AssemblyReference).Namespace,
                                                     typeof(Application.AssemblyReference).Namespace,
                                                     typeof(Infrastructure.AssemblyReference).Namespace,
                                                     typeof(Persistence.AssemblyReference).Namespace,
                                                     typeof(Presentation.AssemblyReference).Namespace)
                               .GetResult ();

        // Assert
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
}