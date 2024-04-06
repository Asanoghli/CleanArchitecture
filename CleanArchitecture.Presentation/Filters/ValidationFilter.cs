using CleanArchitecture.Common.Implementations.Response;
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
            var response = ResponseHelper<List<Error>>.Failed(errors);
            context.Result = new JsonResult(response) { StatusCode = 200 };
        }
        else
        {
            await next();
        }
    }
}
