using CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Identity.Implementations.Repositories;

public class AuthRepository(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager) : IAuthRepository
{
    public async Task<SignInResult> LoginWithPassword(AppUser user,string password,bool rememberMe)
    {
       await userManager.AddPasswordAsync(user, password);
       var result = await signInManager.PasswordSignInAsync(user, password, rememberMe,false);

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

        return user;
    }
    public async Task SignOutAsync()
    {
        await signInManager.SignOutAsync();
    }
}
