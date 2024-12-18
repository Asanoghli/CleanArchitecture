﻿using CleanArchitecture.Application.Contracts.Admin.Users.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers.Admin;
[Route("admin/users")]
[ApiController]
public class AdminUsersController(IUserService _userService) : ControllerBase
{
    [HttpPost("create")]
    [AlphaSoftAuthorization(AlphaSoftAdminPermissions.Users.CreateUser)]
    [TypeFilter<ValidationFilter>(Order =int.MinValue)]
    public async Task<IActionResult> CreateUser([FromBody] AdminCreateUserRequest? user)
    {
        var response = await _userService.CreateUserAsync(user);

        return Ok(response);
    }

    [HttpGet("")]
    [AlphaSoftAuthorization(AlphaSoftAdminPermissions.Users.ViewUsersList)]
    public async Task<IActionResult> GetAllUsers([FromQuery] AdminGetAllUsersRequest filter)
    {
        var users = await _userService.GetAllUsers(filter);
        return Ok(users);
    }

    [HttpPost("update")]
    [AlphaSoftAuthorization(AlphaSoftAdminPermissions.Users.UpdateUser)]
    public async Task<IActionResult> UpdateUser([FromBody] AdminUpdateUserRequest user)
    {
        var response = await _userService.UpdateUserAsync(user);

        return Ok(response);
    }

    [HttpGet("check-email")]
    [AlphaSoftAuthorization(AlphaSoftAdminPermissions.Users.CreateUser)]
    public async Task<IActionResult> CheckEmail(string email)
    {
        var response = await _userService.CheckEmailAddress(email);

        return Ok(response);
    }

}
