using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace OpenCRM.Extensions;

public static class IConfigurationExtensions
{
    public static string SafeGet(this IConfiguration configuration, string key)
    {
        if (configuration[key] is not string value)
        {
            throw new KeyNotFoundException($"Key not defined: '{key}'");
        }

        return value;
    }
}