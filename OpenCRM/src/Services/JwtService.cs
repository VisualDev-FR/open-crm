using Microsoft.IdentityModel.Tokens;
using OpenCRM.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using OpenCRM.Attributes;
using Microsoft.Extensions.Options;
using OpenCRM.Options;

namespace OpenCRM.Services;

[Service]
public class JwtService(IOptions<JwtOptions> _jwtOptions)
{
    private readonly JwtOptions JwtOptions = _jwtOptions.Value;

    public string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: JwtOptions.Issuer,
            audience: JwtOptions.Audience,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
