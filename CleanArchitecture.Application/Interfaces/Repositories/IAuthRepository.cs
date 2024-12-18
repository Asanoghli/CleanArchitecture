﻿using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CleanArchitecture.Application.Interfaces.Repositories;

public interface IAuthRepository
{
    Task<SignInResult> LoginWithPassword(AppUser user, string password, bool rememberMe);
    Task Login(AppUser user, bool rememberMe = false);
    Task<AppUser> FindByUsername(string username);
    Task<AppUser> FindByEmail(string email);
    Task<AppUser> FindById(string Id);
    Task SignOutAsync();
    Task<IdentityResult> ConfirmEmail(string token, AppUser user);
    Task<bool> CheckUserPsswordAsync(AppUser user,string password);
    Task<List<Claim>> GetUserPermissionsClaims(AppUser user);
}
