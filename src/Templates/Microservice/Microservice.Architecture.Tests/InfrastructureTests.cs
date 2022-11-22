namespace Microservice.Architecture.Tests;

public class InfrastructureTests
{
    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects ()
    {
        // Arrange
        var infrastructureAssembly = Infrastructure.AssemblyReference.Assembly;

        // Act
        var testResults = Types.InAssembly (infrastructureAssembly)
                               .ShouldNot ()
                               .HaveDependencyOnAll (typeof(Api.AssemblyReference).Namespace,
                                                     typeof(Persistence.AssemblyReference).Namespace,
                                                     typeof(Presentation.AssemblyReference).Namespace)
                               .GetResult ();

        // Assert
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
}
