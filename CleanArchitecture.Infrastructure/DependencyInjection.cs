using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Implementations.Repositories;
using CleanArchitecture.Infrastructure.Implementations.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddIdentity(services);
        AddUIW(services);
        AddServices(services);

        return services;
    }
    private static void AddUIW(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPageService, PagesService>();
    }
    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<CleanArchitectureDbContext>();
    }
    private static void AddIdentity(IServiceCollection services)
    {
        services.AddIdentity<AppUser, AppRole>(config =>
        {
            config.Password.RequiredUniqueChars = 0;
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequiredLength = 6;
            config.Password.RequireDigit = false;
            config.Password.RequireUppercase = false;
        })
        .AddEntityFrameworkStores<CleanArchitectureDbContext>()
        .AddDefaultTokenProviders();

        services.AddAuthentication().AddJwtBearer(opt =>
        {
            opt.UseSecurityTokenValidators = true;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("WORLD"))
            };

        });
    }
}
