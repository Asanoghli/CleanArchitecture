using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.Infrastructure.Filters;

public class AuthFilter :Attribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if(user == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
