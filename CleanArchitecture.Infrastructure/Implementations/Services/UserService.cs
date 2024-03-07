using AutoMapper;
using CleanArchitecture.Application.Contracts.User.Requests;
using CleanArchitecture.Application.Contracts.User.Responses;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Extensions;

namespace CleanArchitecture.Infrastructure.Implementations.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper _mapper) : IUserService
{
    public async Task<IResponse<CreateUserResponse>> CreateUserAsync(CreateUserRequest user)
    {

        var appUser = _mapper.Map<AppUser>(user);

        var result = await unitOfWork.userRepository.CreateAsync(appUser, user.password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.GetResponseErrors();
            return ResponseHelper<CreateUserResponse>.Failed(errors);
        }

        var createUserResponse = new CreateUserResponse();
        createUserResponse.id = appUser.Id;

        return ResponseHelper<CreateUserResponse>.Success(createUserResponse);
    }


}
