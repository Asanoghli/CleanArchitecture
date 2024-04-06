using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Infrastructure.Implementations.Repositories;
using CleanArchitecture.Infrastructure.Implementations.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        AddDbContext(services);
        AddIdentity(services,configuration);
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
        services.AddScoped<IRolesService, RolesService>();
    }
    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<CleanArchitectureDbContext>();
    }
    private static void AddIdentity(IServiceCollection services,IConfiguration configuration)
    {
        services.AddSingleton<IAuthorizationHandler, AlphaSoftAuthorizationHandler>();

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

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.UseSecurityTokenValidators = true;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetValue<string>("JWT:Issuer"),
                ValidAudience = configuration.GetValue<string>("JWT:Audience"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:Key")))
            };

        });
        services.AddAuthorization(opt =>
        {
            var permissions = AlphaSoftAuthorizationExtension.GetAlphaPermissions();
            for (int i = 0; i < permissions.Length; i++)
            opt.AddPolicy(permissions[i], pol =>
            {
                    pol.AddRequirements(new AlphaSoftRequirements(permissions[i]));
            });
        });
    }
}
