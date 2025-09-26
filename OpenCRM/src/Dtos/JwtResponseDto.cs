using System;

namespace OpenCRM.Dtos;


public class JwtResponseDto
{
    public string AccessToken { get; set; } = string.Empty;

    public DateTime ExpirationTime { get; set; } = DateTime.Now;
}