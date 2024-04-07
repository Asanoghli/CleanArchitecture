using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authorization;
public class AlphaSoftAuthorizationHandler(IServiceProvider serviceProvider) : AuthorizationHandler<AlphaSoftRequirements>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AlphaSoftRequirements requirement)
    {
        var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();


        var user = await userManager.GetUserAsync(context.User);

        var userRoles = await userManager.GetRolesAsync(user);
        var userClaims = await userManager.GetClaimsAsync(user);
        var userRolesClaims = await GetRolesClaims(userRoles, roleManager);
        userRolesClaims.UnionWith(userClaims);

        var hasPermission = userRolesClaims.Any(claim=>claim.Value.Equals(requirement.PermissionName));
        if (hasPermission) context.Succeed(requirement);
        else context.Fail();
    }
    private async Task<HashSet<Claim>> GetRolesClaims(IList<string> rolesNames,RoleManager<AppRole> roleManager)
    {
        var claims = new HashSet<Claim>();
        foreach (var roleName in rolesNames)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            var roleClaims = await roleManager.GetClaimsAsync(role);
            foreach (var claim in roleClaims)
            {
                claims.Add(claim);
            }
        }

        return claims;
    }
}
