
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OpenCRM.Attributes;
using OpenCRM.Dtos;
using OpenCRM.Entities;
using OpenCRM.Services;


[Service]
public class AuthService(UserManager<OpenCrmUser> userManager, JwtService jwtService)
{
    public async Task<JwtResponseDto> LoginAsync(LoginRequestDto login)
    {
        var user = await userManager.FindByNameAsync(login.Username);

        if (user == null || !await userManager.CheckPasswordAsync(user, login.Password))
            throw new InvalidOperationException($"Invalid credentials");

        return new JwtResponseDto
        {
            AccessToken = jwtService.GenerateJwtToken(user),
            ExpirationTime = DateTime.Now.AddHours(1),
        };
    }

    public async Task<JwtResponseDto> RegisterAsync(RegisterRequestDto register)
    {
        string username = await GenerateUsername(register);

        var user = new OpenCrmUser
        {
            FirstName = register.FirstName,
            LastName = register.LastName,
            UserName = username,
            Email = register.Email,
            PhoneNumber = register.PhoneNumber,
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
        };

        var result = await userManager.CreateAsync(user, register.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"User creation failed: {errors}");
        }

        return new JwtResponseDto
        {
            AccessToken = jwtService.GenerateJwtToken(user),
            ExpirationTime = DateTime.UtcNow.AddHours(1)
        };
    }

    private async Task<string> GenerateUsername(RegisterRequestDto register)
    {
        string baseUserName = $"{register.FirstName}.{register.LastName}".ToLower();
        string userName = baseUserName;
        int suffix = 1;

        while (await userManager.FindByNameAsync(userName) != null)
        {
            userName = $"{baseUserName}{suffix}";
            suffix++;
        }

        return userName;
    }
}