using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Infrastructure.Identity.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpGet("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        await authService.Login(loginRequest);

        return Ok();
    }
}
