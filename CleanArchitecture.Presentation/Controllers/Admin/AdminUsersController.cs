using CleanArchitecture.Application.Contracts.User.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers.Admin;
[Route("admin/users")]
public class AdminUsersController(IUserService _userService):AdminController
{
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest user)
    {
        var response = await _userService.CreateUserAsync(user);

        return Ok(response);
    }
}
