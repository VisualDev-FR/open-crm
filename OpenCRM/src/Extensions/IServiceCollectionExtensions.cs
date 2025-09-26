using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenCRM.Attributes;
using OpenCRM.Options;

namespace OpenCRM.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection service)
    {
        var serviceTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(ServiceAttribute.IsService);

        foreach (var t in serviceTypes)
        {
            var baseType = t.BaseType;
            var attr = t.GetCustomAttribute<ServiceAttribute>();

            if (baseType == null || !baseType.IsInterface)
                throw new NullReferenceException();

            switch (attr!.Lifetime)
            {
                case ServiceLifetime.Scoped:
                    break;

                case ServiceLifetime.Transient:
                    break;

                case ServiceLifetime.Singleton:
                    service.AddSingleton(basetype, t);
                    break;

                default:
                    throw new NotSupportedException($"Unsuported Lifetime: '{attr.Lifetime}'");
            }
        }
    }

    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("jwt").Get<JwtOptions>();

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
                ValidIssuer = jwtOptions!.Issuer,
                ValidAudience = jwtOptions!.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
            };
        });
    }
}