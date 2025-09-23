using Microsoft.AspNetCore.Identity;

namespace OpenCRM.Entities;

public class OpenCrmUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}