using System.ComponentModel;

namespace CleanArchitecture.Infrastructure.Authorization;
public static class AlphaSoftAdminPermissions
{
    public const string ADMIN = nameof(ADMIN);

    public static class Users
    {
        public const string CreateUser = $"{nameof(Users)}.{nameof(CreateUser)}";
        public const string ViewUsersList = $"{nameof(Users)}.{nameof(ViewUsersList)}";
        public const string UpdateUser = $"{nameof(Users)}.{nameof(UpdateUser)}";
        public const string DeleteUser = $"{nameof(Users)}.{nameof(DeleteUser)}";
    }
    public static class Roles
    {
        public const string ROLESTEST = nameof(ROLESTEST);
    }
}
