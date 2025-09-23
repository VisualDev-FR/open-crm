using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        string jwtKey = configuration.SafeGet("Jwt:Key");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.SafeGet("Jwt:Issuer"),
                ValidAudience = configuration.SafeGet("Jwt:Audience"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
            };
        });

        return services;
    }
}