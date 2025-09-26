using System.IdentityModel.Tokens.Jwt;
using OpenCRM.Entities;
using OpenCRM.Options;
using OpenCRM.Services;

using MSOptions = Microsoft.Extensions.Options.Options;

namespace OpenCRM.Tests.Services;


public class JwtServiceTests
{
    [Fact]
    public void GenerateJwtToken_WithValidUser_ReturnsValidToken()
    {
        var jwtOptions = new JwtOptions
        {
            SecretKey = "super-very-long-and-top-secret-key1234567890",
            Issuer = "OpenCRM",
            Audience = "OpenCRMUsers"
        };

        var optionsMock = MSOptions.Create(jwtOptions);
        var jwtService = new JwtService(optionsMock);

        var user = new User { Id = "id1", Email = "test@example.com" };
        var token = jwtService.GenerateJwtToken(user);

        Assert.False(string.IsNullOrEmpty(token));

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        Assert.Equal(jwtOptions.Issuer, jwt.Issuer);
        Assert.Equal(jwtOptions.Audience, jwt.Audiences.First());
        Assert.True(jwt.ValidTo > DateTime.UtcNow);
    }
}