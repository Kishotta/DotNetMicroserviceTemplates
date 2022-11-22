using System.Reflection;
using MediatR;

namespace Microservice.Architecture.Tests;

public class ApplicationTests
{
    private readonly Assembly _applicationAssembly = Application.AssemblyReference.Assembly;

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects ()
    {
        var testResults = Types.InAssembly (_applicationAssembly)
                               .ShouldNot ()
                               .HaveDependencyOnAll (typeof(Api.AssemblyReference).Namespace,
                                                     typeof(Infrastructure.AssemblyReference).Namespace,
                                                     typeof(Persistence.AssemblyReference).Namespace,
                                                     typeof(Presentation.AssemblyReference).Namespace)
                               .GetResult ();

        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }

    [Fact]
    public void Handlers_Should_FollowNamingConvention ()
    {
        var testResults = Types.InAssembly (_applicationAssembly)
                               .That ()
                               .AreClasses ()
                               .And ()
                               .ImplementInterface(typeof(IRequestHandler<,>))
                               .Should ()
                               .HaveNameEndingWith ("Handler")
                               .GetResult ();
        
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
    
    [Fact]
    public void Handlers_Should_ImplementIRequestHandler ()
    {
        var testResults = Types.InAssembly (_applicationAssembly)
                               .That ()
                               .AreClasses()
                               .And ()
                               .HaveNameEndingWith("Handler")
                               .Should ()
                               .ImplementInterface(typeof(IRequestHandler<,>))
                               .GetResult ();
        
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
    
    [Fact]
    public void Handlers_Should_Have_DependencyOnDomain ()
    {
        var testResults = Types.InAssembly (_applicationAssembly)
                               .That ()
                               .AreClasses ()
                               .And ()
                               .HaveNameEndingWith ("Handler")
                               .Should ()
                               .HaveDependencyOn (typeof(Domain.AssemblyReference).Namespace)
                               .GetResult ();
        
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
}