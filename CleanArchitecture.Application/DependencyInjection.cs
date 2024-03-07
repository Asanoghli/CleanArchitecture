using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidation(conf =>
        {
            conf.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            conf.ValidatorOptions.CascadeMode = FluentValidation.CascadeMode.StopOnFirstFailure;
        });

        return services;
    }
}
