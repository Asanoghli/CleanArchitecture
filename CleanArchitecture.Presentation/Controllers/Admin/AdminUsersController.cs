using CleanArchitecture.Application.Contracts.Admin.Users.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers.Admin;
[Route("admin/users")]
[ApiController]
public class AdminUsersController(IUserService _userService):ControllerBase
{
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] AdminCreateUserRequest user)
    {
        var response = await _userService.CreateUserAsync(user);

        return Ok(response);
    }
}
