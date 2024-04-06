using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Infrastructure.Authorization;
public class AlphaSoftAuthorizationHandler : AuthorizationHandler<AlphaSoftRequirements>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AlphaSoftRequirements requirement)
    {
        var hasPermission = context.User.HasClaim(claim => claim.Type.Equals(AlphaSoftAdminPermissions.ADMINPERMISSION) && claim.Value.Equals(requirement.PermissionName));

        if (hasPermission) context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
