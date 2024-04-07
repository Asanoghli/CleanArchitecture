using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Seed;
public static class SeedDatabase
{
    public static async Task Seed(this IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

        var existedUser = await userManager.FindByNameAsync("AlphaSoft");

        if (existedUser is null)
        {
            existedUser = new AppUser();
            existedUser.FirstName = "Alpha";
            existedUser.LastName = "Soft";
            existedUser.UserName = "AlphaSoft";
            existedUser.Email = "AlphaSoft@AlphaSoft.Com";
            existedUser.EmailConfirmed = true;

            await userManager.CreateAsync(existedUser,"Drakula9X!.");
            var claims = AlphaSoftAuthorizationExtension.GetAlphaPermissions();
            var res = await userManager.AddClaimsAsync(existedUser, claims);
        }

    }
}
