using System;
using System.Reflection;

namespace OpenCRM.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class ServiceAttribute : Attribute
{
    public static bool IsService(Type t)
    {
        return t.IsClass && !t.IsAbstract && t.GetCustomAttribute<ServiceAttribute>() != null;
    }
}
