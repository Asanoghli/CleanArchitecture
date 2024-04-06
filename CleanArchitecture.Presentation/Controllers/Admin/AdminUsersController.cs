using CleanArchitecture.Application.Contracts.Admin.Users.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers.Admin;
[Route("admin/users")]
[ApiController]
public class AdminUsersController(IUserService _userService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] AdminCreateUserRequest user)
    {
        var response = await _userService.CreateUserAsync(user);

        return Ok(response);
    }

    [HttpGet("")]
    [Authorize]
    public async Task<IActionResult> GetAllUsers([FromQuery] AdminGetAllUsersRequest filter)
    {
        var users = await _userService.GetAllUsers(filter);
        return Ok(users);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateUser([FromBody] AdminUpdateUserRequest user)
    {
        var response = await _userService.UpdateUserAsync(user);

        return Ok(response);
    }

}
