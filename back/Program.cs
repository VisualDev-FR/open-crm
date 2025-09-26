using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OpenCRM;
using OpenCRM.Entities;
using OpenCRM.Extensions;
using OpenCRM.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.MapOptions<JwtOptions>("jwt");

builder.Services.AddServices();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// database seeding
app.ResetDatabase();
app.ExecuteSqlFiles("datas/seeding");
app.GenerateUserSeeds();

app.Run();
