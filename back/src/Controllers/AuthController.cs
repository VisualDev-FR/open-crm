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

        if (jwt != null)
        {
            return Ok(jwt);
        }

        return Unauthorized();
    }
}
