using CleanArchitecture.Application.Contracts.User.Requests;
using CleanArchitecture.Application.Contracts.User.Responses;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Responses;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Infrastructure.Identity.Models;
using CleanArchitecture.Infrastructure.Implementations.Response;

namespace CleanArchitecture.Infrastructure.Identity.Implementations.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<IResponse<CreateUserResponse>> CreateUserAsync(CreateUserRequest user)
    {
        var createUserResponse = default(CreateUserResponse);

        var appUser = new AppUser();
        appUser.Email = "asanoghli@gmail.com";
        appUser.UserName = "Asanoghli";
        appUser.FirstName = "Levan";
        appUser.LastName = "Asanoghli";


        var result = await userRepository.CreateAsync(appUser, "drakula9x");
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(error => new Error
            {
                errorKey = error.Code,
                errorMessage = error.Description
            });

            return ResponseHelper<CreateUserResponse>.Failed(errors);
        }


        createUserResponse = new CreateUserResponse();
        createUserResponse.id = appUser.Id;

        return ResponseHelper<CreateUserResponse>.Success(createUserResponse);
    }
}
