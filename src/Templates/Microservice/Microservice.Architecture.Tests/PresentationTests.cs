using System.Reflection;
using MediatR;
using Microservice.Presentation.Abstractions;

namespace Microservice.Architecture.Tests;

public class PresentationTests
{
    private Assembly _presentationAssembly;
    
    public PresentationTests ()
    {
        _presentationAssembly = Presentation.AssemblyReference.Assembly;
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects ()
    {
        var testResults = Types.InAssembly (_presentationAssembly)
                               .ShouldNot ()
                               .HaveDependencyOnAll (typeof(Api.AssemblyReference).Namespace,
                                                     typeof(Infrastructure.AssemblyReference).Namespace,
                                                     typeof(Persistence.AssemblyReference).Namespace)
                               .GetResult ();
        
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }

    [Fact]
    public void Controllers_Should_InheritApiController ()
    {
        // controllers should use ApiController as base
        var testResults = Types.InAssembly (_presentationAssembly)
                               .That ()
                               .AreNotAbstract()
                               .And ()
                               .HaveNameEndingWith("Controller")
                               .Should ()
                               .Inherit(typeof(ApiController))
                               .GetResult ();
        
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
    
    [Fact]
    public void Controllers_Should_HaveDependencyOnMediatR ()
    {
        var testResults = Types.InAssembly (_presentationAssembly)
                               .That ()
                               .HaveNameEndingWith("Controller")
                               .Should ()
                               .HaveDependencyOn (typeof(IMediator).Namespace)
                               .GetResult ();
        
        testResults.IsSuccessful
                   .Should ()
                   .BeTrue ();
    }
}