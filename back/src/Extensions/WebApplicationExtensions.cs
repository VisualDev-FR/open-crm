using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using OpenCRM.Entities;

namespace OpenCRM.Extensions;

public static class WebApplicationExtensions
{
    public static void ResetDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
    public static void GenerateUserSeeds(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<OpenCrmUser>>();
            var adminUser = new OpenCrmUser
            {
                UserName = "admin",
                Email = "admin@crm.com",
                EmailConfirmed = true,
            };

            var result = userManager.CreateAsync(adminUser, "Admin123!").GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Code: {error.Code}, Description: {error.Description}");
                }
            }
        }
    }

    public static void ExecuteSqlFiles(this WebApplication app, string directory)
    {
        using (var scope = app.Services.CreateScope())
        {
            AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            foreach (var path in Directory.GetFiles(directory))
            {
                dbContext.Database.ExecuteSqlRaw(File.ReadAllText(path));
            }
        }
    }

}