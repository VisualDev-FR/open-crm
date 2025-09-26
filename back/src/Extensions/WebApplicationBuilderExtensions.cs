using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace OpenCRM.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void MapOptions<T>(this WebApplicationBuilder builder, string key) where T : class
    {
        builder.Services.Configure<T>(builder.Configuration.GetSection(key));
    }
}