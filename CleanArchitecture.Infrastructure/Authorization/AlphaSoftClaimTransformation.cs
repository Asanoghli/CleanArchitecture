using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authorization;
public class AlphaSoftClaimTransformation(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : IClaimsTransformation
{

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        return principal;
    }
}
