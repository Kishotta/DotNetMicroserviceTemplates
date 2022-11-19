using System.Reflection;

namespace Microservice.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof (AssemblyReference).Assembly;
}