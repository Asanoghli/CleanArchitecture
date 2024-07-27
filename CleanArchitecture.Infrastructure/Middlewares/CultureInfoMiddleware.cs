using CleanArchitecture.Common.Localizations;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Middlewares;
public class CultureInfoMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var containsCulture = context.Request.Headers.Any(header => header.Key.Equals("Content-Language"));
        var language = context.Request.Headers.FirstOrDefault(header => header!.Key!.Equals("Content-Language"))!.Value.ToString().ToLower();
        var culture = containsCulture ? language : SupportedCultureInfos.DEFAULT;

        CultureInfo.CurrentCulture = SupportedCultureInfos.GetCultureInfo(culture);
        CultureInfo.CurrentUICulture = SupportedCultureInfos.GetCultureInfo(culture);
        Thread.CurrentThread.CurrentCulture = SupportedCultureInfos.GetCultureInfo(culture);
        Thread.CurrentThread.CurrentUICulture = SupportedCultureInfos.GetCultureInfo(culture);

        await next(context);
    }
}
