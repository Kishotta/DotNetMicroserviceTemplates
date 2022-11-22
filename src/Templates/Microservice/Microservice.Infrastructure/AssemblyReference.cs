using System.Reflection;

namespace Microservice.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof (AssemblyReference).Assembly;
}