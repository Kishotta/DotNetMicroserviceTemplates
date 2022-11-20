using System.Reflection;

namespace Microservice.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof (AssemblyReference).Assembly;
}