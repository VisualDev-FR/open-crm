using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCRM.Dtos;

namespace OpenCRM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
    {
        var jwt = await authService.LoginAsync(login);

        return Ok(jwt);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto register)
    {
        var jwt = await authService.RegisterAsync(register);

        return Ok(jwt);
    }
}
