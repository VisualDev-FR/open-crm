using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OpenCRM.Attributes;

namespace OpenCRM.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection service)
    {
        var serviceTypes = Assembly.GetExecutingAssembly().GetTypes().Where(ServiceAttribute.IsService);

        foreach (Type type in serviceTypes)
        {
            service.AddScoped(type);
        }
    }
}