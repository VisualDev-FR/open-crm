using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenCRM.Entities;
using OpenCRM.Extensions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using OpenCRM.Attributes;

namespace OpenCRM.Services;

[Service]
public class JwtService(IConfiguration config)
{
    public string GenerateJwtToken(OpenCrmUser user)
    {
        var jwtKey = config.SafeGet("Jwt:Key");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config.SafeGet("Jwt:Issuer"),
            audience: config.SafeGet("Jwt:Audience"),
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
