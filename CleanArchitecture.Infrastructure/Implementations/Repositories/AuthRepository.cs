using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories;

public class AuthRepository(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : IAuthRepository
{
    public async Task<SignInResult> LoginWithPassword(AppUser user, string password, bool rememberMe)
    {
        await userManager.AddPasswordAsync(user, password);
        var result = await signInManager.PasswordSignInAsync(user, password, rememberMe, false);

        return result;
    }
    public async Task Login(AppUser user, bool rememberMe = false)
    {
        await signInManager.SignInAsync(user, rememberMe);
    }
    public async Task<AppUser> FindByEmail(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        return user;
    }
    public async Task<AppUser> FindByUsername(string username)
    {
        var user = await userManager.FindByNameAsync(username);

        return user!;
    }
    public async Task<AppUser> FindById(string Id)
    {
        var user = await userManager.FindByIdAsync(Id);

        return user!;
    }
    public async Task SignOutAsync()
    {
        await signInManager.SignOutAsync();
    }
    public async Task<IdentityResult> ConfirmEmail(string token, AppUser user)
    {
        var response = await userManager.ConfirmEmailAsync(user, token);

        return response;
    }
    public async Task<bool> CheckUserPsswordAsync(AppUser user, string password)
    {
        var result = await signInManager.CheckPasswordSignInAsync(user, password,false);

        return result.Succeeded;
    }


}
