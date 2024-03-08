using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<AppUser> FindByEmail(string email);
    Task<AppUser> FindById(string id);
    Task<IdentityResult> AddToRole(AppUser user,string roleName);
    Task<IdentityResult> AddToRoles(AppUser user, string[] roleNames);
    Task<IdentityResult> RemoveFromRole(AppUser user,string roleName);
    Task<IdentityResult> RemoveFromRoles(AppUser user, string[] roleNames);
    Task<bool> IsPhoneNumberBusy(string phoneNumber, Guid currentUserId = default);
    Task<bool> IsEmailBusy(string email,Guid currentUserId = default);
    Task<IdentityResult> CreateAsync(AppUser user,string password = default);
    Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token);
    Task<string> GenerateConfirmationToken(AppUser user);
    IQueryable<AppUser> GetAllUsersQuery(bool AsNoTracking = true);
}
