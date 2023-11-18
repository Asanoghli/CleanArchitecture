using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories;

public interface IAuthRepository
{
    Task<SignInResult> LoginWithPassword(AppUser user, string password, bool rememberMe);
    Task Login(AppUser user, bool rememberMe = false);
    Task<AppUser> FindByUsername(string username);
    Task<AppUser> FindByEmail(string email);
    Task SignOutAsync();
}
