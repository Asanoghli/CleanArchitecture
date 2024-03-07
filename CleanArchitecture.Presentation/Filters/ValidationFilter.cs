using CleanArchitecture.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.Presentation.Filters;
public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var isInvalid = !context.ModelState.IsValid;
        if (isInvalid)
        {
            var errors = context.ModelState.GetResponseErrors();
            context.Result = new JsonResult(errors) { StatusCode = 403 };
        }
        else
        {
            await next();
        }
    }
}
