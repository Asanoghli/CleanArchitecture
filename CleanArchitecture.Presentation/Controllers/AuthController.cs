using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequest userCredintials)
    {
        var response = await authService.Login(userCredintials);

        return Ok(response);
    }
    [HttpPost("validate-token")]
    public async Task<IActionResult> ValidateToken( string token)
    {
        var isValid = await authService.ValidateToken(token);

        return Ok(isValid);
    }
}
