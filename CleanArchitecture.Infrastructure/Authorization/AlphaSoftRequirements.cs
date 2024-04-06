using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Authorization;
public class AlphaSoftRequirements : IAuthorizationRequirement
{
    public string PermissionName;
    public AlphaSoftRequirements(string permissionName)
    {
        PermissionName = permissionName;
    }
}
