using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories;
public class RolesRepository(RoleManager<AppRole> roleManager) : IRolesRepository
{
    public async Task<AppRole> FindRoleById(string roleId)
    {
        return await roleManager.FindByIdAsync(roleId);
    }
    public async Task<AppRole> FindRoleByName(string roleName)
    {
        return await roleManager.FindByNameAsync(roleName);
    }
    public async Task<IEnumerable<AppRole>> GetAllRoles(bool asNoTracking = true)
    {
        if (asNoTracking)
            return roleManager.Roles.AsNoTracking();

        return roleManager.Roles;
    }
    public async Task<IdentityResult> CreateRole(AppRole role)
    {
        return await roleManager.CreateAsync(role);
    }
    public async Task<IList<Claim>> GetRoleClaims(AppRole role)
    {
        var claims = await roleManager.GetClaimsAsync(role);

        return claims;
    }
    public async Task<IdentityResult> AddRoleClaim(AppRole role, Claim claim)
    {
        return await roleManager.AddClaimAsync(role, claim);
    }
}
