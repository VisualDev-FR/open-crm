using System.ComponentModel.DataAnnotations;

namespace OpenCRM.Dtos;


public class LoginRequestDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
    public string Username { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}