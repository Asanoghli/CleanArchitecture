using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CleanArchitecture.Presentation.Controllers;

public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpGet("{culture}/login")]
    [HttpGet("login")]
    public async Task<IActionResult> Login(string culture)
    {
        var response = await authService.ConfirmEmail("123",Guid.Empty);

        return Ok(response);
    }
}
