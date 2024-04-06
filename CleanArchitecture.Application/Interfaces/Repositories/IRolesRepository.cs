using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CleanArchitecture.Application.Interfaces.Repositories;
public interface IRolesRepository
{
    Task<AppRole> FindRoleById(string roleId);

    Task<AppRole> FindRoleByName(string roleName);

    Task<IEnumerable<AppRole>> GetAllRoles(bool asNoTracking = true);

    Task<IdentityResult> CreateRole(AppRole role);

    Task<IList<Claim>> GetRoleClaims(AppRole role);
    Task<IdentityResult> AddRoleClaim(AppRole role, Claim claim);

}
