using CleanArchitecture.Infrastructure.Authorization;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Extensions;
public static class AlphaSoftAuthorizationExtension
{
    public static IEnumerable<Claim> GetAlphaPermissions()
    {
        var permissions = typeof(AlphaSoftAdminPermissions)
            .GetNestedTypes().SelectMany(subClass => subClass.GetFields()).Select(fieldInfo=>fieldInfo.GetValue(null) as string) ;

        var claimpermissions = permissions.Select(permission => new Claim(AlphaSoftAdminPermissions.ADMIN, permission));

        return claimpermissions;
    }
}

