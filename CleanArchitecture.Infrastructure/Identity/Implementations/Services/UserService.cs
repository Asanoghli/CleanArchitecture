using CleanArchitecture.Application.Contracts.User.Requests;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Infrastructure.Identity.Implementations.Repositories;
using CleanArchitecture.Infrastructure.Identity.Models;

namespace CleanArchitecture.Infrastructure.Identity.Implementations.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<Guid> CreateUserAsync(CreateUserRequest user)
    {
        var appUser = new AppUser();
        appUser.Email = "asanoghli@gmail.com";
        appUser.UserName = "Asanoghli";
        appUser.FirstName = "Levan";
        appUser.LastName = "Asanoghli";


        var result =await userRepository.CreateAsync(appUser,"drakula9x");


        return appUser.Id;
    }
}
