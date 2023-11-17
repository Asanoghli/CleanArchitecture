using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Identity.Implementations.Repositories;
using CleanArchitecture.Infrastructure.Identity.Implementations.Services;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddIdentity(services);
        AddRepositories(services);
        AddServices(services);

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
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
        }).AddEntityFrameworkStores<CleanArchitectureDbContext>()
        .AddDefaultTokenProviders()
        ;

    }
}
