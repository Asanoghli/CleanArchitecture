using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Infrastructure.Authorization
{
    public class AlphaSoftAuthorization : AuthorizeAttribute
    {
        public AlphaSoftAuthorization(string AlphaSoftPermission)
        {
            Policy = AlphaSoftPermission;
        }
    }
}
