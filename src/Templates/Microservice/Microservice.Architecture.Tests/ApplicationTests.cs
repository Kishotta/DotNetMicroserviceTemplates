using Microservice.Application.Abstractions.Messaging;

namespace Microservice.Architecture.Tests;

public class ApplicationTests
{
    private readonly Assembly _applicationAssembly = Microservice.Application.AssemblyReference.Assembly;

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects ()
    {
        var policy = Policy.Define ("Application Project Policy", "Application Project should adhere to architectural conventions")
                           .For (Types.InAssembly (_applicationAssembly))
                           .Add (type => type.ShouldNot ().HaveDependencyOnAll (typeof (Api.AssemblyReference).Namespace,
                                                                                typeof (Infrastructure.AssemblyReference).Namespace,
                                                                                typeof (Persistence.AssemblyReference).Namespace,
                                                                                typeof (Presentation.AssemblyReference).Namespace),
                                 "Enforcing Application Project Architecture",
                                 "Application Project should adhere to architectural convention");

        var results = policy.Evaluate ().Results;

        results.Should ().OnlyContain (result => result.IsSuccessful);
    }

    [Fact]
    public void Queries_Should_AdhereToArchitectureConvention ()
    {
        var policy = Policy.Define ("Application Query Policy", "Queries should adhere to architectural convention")
                           .For (Types.InAssembly (_applicationAssembly))
                           .Add (type => type.That ().AreClasses ()
                                             .And ().ImplementInterface (typeof (IQuery<>))
                                             .Should ().HaveNameEndingWith ("Query")
                                             .And ().BeSealed (),
                                 "Enforcing Query naming",
                                 "Query classes should have names ending with 'Query'")
                           .Add (type => type.That ().HaveNameEndingWith ("Query")
                                             .Should ().BeClasses ()
                                             .And ().BeSealed ()
                                             .And ().ImplementInterface (typeof (IQuery<>)),
                                 "Enforcing Query Dependency",
                                 "Query classes should implement the 'IQuery' interface");

        var results = policy.Evaluate ().Results;

        results.Should ().OnlyContain (result => result.IsSuccessful);
    }

    [Fact]
    public void QueryHandlers_Should_AdhereToArchitectureConvention ()
    {
        var policy = Policy.Define ("Application Query Handler Policy", "Query Handlers should adhere to architectural convention")
                           .For (Types.InAssembly (_applicationAssembly))
                           .Add (type => type.That ().AreClasses ()
                                             .And ().ImplementInterface (typeof (IQueryHandler<,>))
                                             .Should ().HaveNameEndingWith ("QueryHandler")
                                             .And ().BeSealed ()
                                             .And ().HaveDependencyOn (typeof (Domain.AssemblyReference).Namespace),
                                 "Enforcing Query Handler naming",
                                 "Query Handler classes should have names ending with 'QueryHandler'")
                           .Add (type => type.That ().HaveNameEndingWith ("QueryHandler")
                                             .Should ().BeClasses ()
                                             .And ().BeSealed ()
                                             .And ().ImplementInterface (typeof (IQueryHandler<,>)),
                                 "Enforcing Query Handler Dependency",
                                 "Query classes should implement the 'IQueryHandler' interface");

        var results = policy.Evaluate ().Results;

        results.Should ().OnlyContain (result => result.IsSuccessful);
    }

    [Fact]
    public void Commands_Should_AdhereToArchitectureConvention ()
    {
        var policy = Policy.Define ("Application Command Policy", "Commands should adhere to architectural convention")
                           .For (Types.InAssembly (_applicationAssembly))
                           .Add (type => type.That ().AreClasses ()
                                             .And ().ImplementInterface (typeof (ICommand))
                                             .Or ().ImplementInterface (typeof (ICommand<>))
                                             .Should ().HaveNameEndingWith ("Command")
                                             .And ().BeSealed (),
                                 "Enforcing Command naming",
                                 "Command classes should have names ending with 'Command'")
                           .Add (type => type.That ().HaveNameEndingWith ("Command")
                                             .And ().AreClasses ()
                                             .Should ().BeSealed ()
                                             .And ().ImplementInterface (typeof (ICommand))
                                             .Or ().ImplementInterface (typeof (ICommand<>)),
                                 "Enforcing Command Dependency",
                                 "Command classes should implement the 'ICommand' interface");

        var results = policy.Evaluate ().Results;

        results.Should ().OnlyContain (result => result.IsSuccessful);
    }

    [Fact]
    public void CommandHandlers_Should_AdhereToArchitectureConvention ()
    {
        var policy = Policy.Define ("Application Command Handler Policy", "Command Handlers should adhere to architectural convention")
                           .For (Types.InAssembly (_applicationAssembly))
                           .Add (type => type.That ().AreClasses ()
                                             .And ().ImplementInterface (typeof (ICommandHandler<>))
                                             .Or ().ImplementInterface (typeof (ICommandHandler<,>))
                                             .Should ().HaveNameEndingWith ("CommandHandler")
                                             .And ().BeSealed ()
                                             .And ().HaveDependencyOn (typeof (Domain.AssemblyReference).Namespace),
                                 "Enforcing Command Handler naming",
                                 "Command Handler classes should have names ending with 'CommandHandler'")
                           .Add (type => type.That ().HaveNameEndingWith ("CommandHandler")
                                             .Should ().BeClasses ()
                                             .And ().BeSealed ()
                                             .And ().ImplementInterface (typeof (ICommandHandler<>))
                                             .Or ().ImplementInterface (typeof (ICommandHandler<,>)),
                                 "Enforcing Command Handler Dependency",
                                 "Command classes should implement the 'ICommandHandler' interface");

        var results = policy.Evaluate ().Results;

        results.Should ().OnlyContain (result => result.IsSuccessful);
    }
}