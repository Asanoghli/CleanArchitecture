using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace CleanArchitecture.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<AppUser> GetByEmail(string email);
    Task<bool> AddToRole(string roleName);
    Task<bool> AddToRoles(string[] roleNames);
    Task<bool> RemoveFromRole(string roleName);
    Task<bool> RemoveFromRoles(string[] roleNames);
    Task<bool> CheckPhoneNumber(string phoneNumber);
    Task<bool> CheckEmailAddress(string email);
    Task<IdentityResult> CreateAsync(AppUser user,string password = default);
}
