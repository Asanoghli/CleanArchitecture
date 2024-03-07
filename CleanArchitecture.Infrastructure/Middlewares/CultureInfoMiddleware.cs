using CleanArchitecture.Common.Localizations;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Middlewares;
public class CultureInfoMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var containsCulture = context.Request.Headers.Any(header => header.Key.Equals("Content-Language"));
        if (containsCulture)
        {
            var language = context.Request.Headers.First(header=>header!.Key!.Equals("Content-Language"))!.Value;
            CultureInfo.CurrentCulture = SupportedCultureInfos.GetCultureInfo(language);
            CultureInfo.CurrentUICulture = SupportedCultureInfos.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = SupportedCultureInfos.GetCultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = SupportedCultureInfos.GetCultureInfo(language);
        }
        else
        {
            CultureInfo.CurrentCulture = SupportedCultureInfos.GetCultureInfo(SupportedCultureInfos.DEFAULT);
            CultureInfo.CurrentUICulture = SupportedCultureInfos.GetCultureInfo(SupportedCultureInfos.DEFAULT);
            Thread.CurrentThread.CurrentCulture = SupportedCultureInfos.GetCultureInfo(SupportedCultureInfos.DEFAULT);
            Thread.CurrentThread.CurrentUICulture = SupportedCultureInfos.GetCultureInfo(SupportedCultureInfos.DEFAULT);
        }
        await next(context);
    }
}
