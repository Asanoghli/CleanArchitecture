using CleanArchitecture.Application.Contracts.User.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet("users")]
    public async Task<IActionResult> Index(CreateUserRequest request)
    {
        var response = await userService.CreateUserAsync(request);
        var modelState = ModelState.ErrorCount;
        return Ok(response);
    }
}
