using CleanArchitecture.Infrastructure.Authorization;

namespace CleanArchitecture.Infrastructure.Extensions;
    public static class AlphaSoftAuthorizationExtension
    {
        public static string[] GetAlphaPermissions()
        {
            var permissions = typeof(AlphaSoftAdminPermissions).GetFields();
            var permissionsToReturn = new string[permissions.Length - 1];
            for (int i = 1,k=0; i < permissions.Length; i++,k++)
            {
                permissionsToReturn[k] = permissions[i].Name;
            }

            return permissionsToReturn;
        }
    }

