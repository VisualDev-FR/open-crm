using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace OpenCRM.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ServiceAttribute(ServiceLifetime _lifetime = ServiceLifetime.Scoped) : Attribute
{
    public ServiceLifetime Lifetime { get; } = _lifetime;

    public static bool IsService(Type t)
    {
        return t.IsClass && !t.IsAbstract && t.GetCustomAttribute<ServiceAttribute>() != null;
    }
}
