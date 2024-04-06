using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;

public class AppRole : IdentityRole<Guid>
{
    public AppRole(string roleName):base(roleName)
    {
    }
    public AppRole()
    {
    }
}
