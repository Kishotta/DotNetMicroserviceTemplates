using System.Reflection;

namespace Microservice.Api;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof (AssemblyReference).Assembly;
}