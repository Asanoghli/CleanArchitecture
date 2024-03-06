using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.Infrastructure.Filters;

public class AuthFilter(UserManager<AppUser> userManager) : IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        var signedInUser = await userManager.GetUserAsync(user);
        if(signedInUser != null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
