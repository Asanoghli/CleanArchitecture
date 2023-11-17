using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddFluentValidation(conf =>
        {
            conf.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //conf.ValidatorOptions.CascadeMode = FluentValidation.CascadeMode.Continue;
        });

        return services;
    }
}
