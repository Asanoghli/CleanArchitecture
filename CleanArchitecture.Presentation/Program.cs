using CleanArchitecture.Application;
using CleanArchitecture.Common.Localizations;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Middlewares;
using CleanArchitecture.Infrastructure.Seed;
using CleanArchitecture.Presentation.Filters;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<CultureInfoMiddleware>();
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ValidationFilter>(order: int.MinValue);
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(x => x.AddPolicy("MyPolicy", opt =>
{
    opt.WithOrigins(["https://localhost:44359/", "localhost:44359/"]).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
}));
builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(SupportedCultureInfos.GetDefaultCulture());
    options.SupportedCultures = SupportedCultureInfos.GetAllCultureInfoValues();
    options.SupportedUICultures = SupportedCultureInfos.GetAllCultureInfoValues(); ;
});
var app = builder.Build();
await app.Services.Seed();
// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseMiddleware<CultureInfoMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
