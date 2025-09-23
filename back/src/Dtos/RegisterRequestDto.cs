using System.ComponentModel.DataAnnotations;
using OpenCRM.Attributes.Validation;

namespace OpenCRM.Dtos;

public class RegisterRequestDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    [Password(ErrorMessage = "Invalid password")]
    public string Password { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Invalid phone number")]
    public string? PhoneNumber { get; set; } = null;
}