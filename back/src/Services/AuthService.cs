
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OpenCRM.Attributes;
using OpenCRM.Dtos;
using OpenCRM.Entities;
using OpenCRM.Services;


[Service]
public class AuthService(UserManager<OpenCrmUser> userManager, JwtService jwtService)
{
    public async Task<JwtResponseDto?> LoginAsync(LoginRequestDto login)
    {
        var user = await userManager.FindByNameAsync(login.Username);

        if (user == null || !await userManager.CheckPasswordAsync(user, login.Password))
            return null;

        return new JwtResponseDto
        {
            AccessToken = jwtService.GenerateJwtToken(user),
            ExpirationTime = DateTime.Now.AddHours(1),
        };
    }
}