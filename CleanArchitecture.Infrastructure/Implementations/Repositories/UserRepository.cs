using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories;

public class UserRepository(UserManager<AppUser> userManager) : IUserRepository
{
    public Task<bool> AddToRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddToRoles(string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckEmailAddress(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckPhoneNumber(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> CreateAsync(AppUser user, string password = default)
    {
        return await userManager.CreateAsync(user);
    }

    public Task<AppUser> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveFromRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveFromRoles(string[] roleNames)
    {
        throw new NotImplementedException();
    }
}
