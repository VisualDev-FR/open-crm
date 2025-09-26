using System.Threading.Tasks;
using OpenCRM.Dtos;

namespace OpenCRM.Interfaces;

public interface IAuthService
{
    public Task<JwtResponseDto> LoginAsync(LoginRequestDto login);

    public Task<JwtResponseDto> RegisterAsync(RegisterRequestDto register);
}