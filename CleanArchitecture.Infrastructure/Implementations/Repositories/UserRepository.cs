using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories;

public class UserRepository(UserManager<AppUser> userManager) : IUserRepository
{
    public async Task<IdentityResult> AddToRole(AppUser user, string roleName)
    {
        return await userManager.AddToRoleAsync(user, roleName);
    }

    public async Task<IdentityResult> AddToRoles(AppUser user, string[] roleNames)
    {
        return await userManager.AddToRolesAsync(user, roleNames);
    }

    public async Task<bool> IsEmailBusy(string email, Guid currentUserId)
    {
        var isBusy = default(bool);
        if (currentUserId == default)
        {
            isBusy = await userManager.Users.AnyAsync(user => user.Email!.Equals(email));
        }
        else
        {
            isBusy = await userManager.Users.AnyAsync(user => user.Email.Equals(email) && !user.Id.Equals(currentUserId));
        }
        return isBusy;
    }

    public async Task<bool> IsPhoneNumberBusy(string phoneNumber, Guid currentUserId = default)
    {
        var isBusy = default(bool);
        if (currentUserId == default)
        {
            isBusy = await userManager.Users.AnyAsync(user => user.PhoneNumber!.Equals(phoneNumber));
        }
        else
        {
            isBusy = await userManager.Users.AnyAsync(user => user.PhoneNumber.Equals(phoneNumber) && !user.Id.Equals(currentUserId));
        }
        return isBusy;
    }

    public async Task<IdentityResult> CreateAsync(AppUser user, string password = default)
    {
        return await userManager.CreateAsync(user);
    }

    public async Task<AppUser> FindByEmail(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<AppUser> FindById(string id)
    {
        return await userManager.FindByIdAsync(id);
    }

    public async Task<IdentityResult> RemoveFromRole(AppUser user, string roleName)
    {
        return await userManager.RemoveFromRoleAsync(user, roleName);
    }

    public async Task<IdentityResult> RemoveFromRoles(AppUser user, string[] roleNames)
    {
        return await userManager.RemoveFromRolesAsync(user, roleNames);
    }

    public async Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token)
    {
        return await userManager.ConfirmEmailAsync(user, token);
    }

    public async Task<string> GenerateConfirmationToken(AppUser user)
    {
        return await userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public IQueryable<AppUser> GetAllUsersQuery(bool AsNoTracking = true)
    {
        if (AsNoTracking)
            return userManager.Users.AsNoTracking();
        else
            return userManager.Users;
    }
}
