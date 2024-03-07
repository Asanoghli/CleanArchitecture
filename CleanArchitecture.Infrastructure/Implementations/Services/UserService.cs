﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Admin.Users.Requests;
using CleanArchitecture.Application.Contracts.Admin.Users.Responses;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application.Resources;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Extensions;

namespace CleanArchitecture.Infrastructure.Implementations.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper _mapper) : IUserService
{
    public async Task<IResponse<AdminCreateUserResponse>> CreateUserAsync(AdminCreateUserRequest user)
    {

        var appUser = _mapper.Map<AppUser>(user);

        var result = await unitOfWork.userRepository.CreateAsync(appUser, user.password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.GetResponseErrors();
            return ResponseHelper<AdminCreateUserResponse>.Failed(errors);
        }

        var createUserResponse = new AdminCreateUserResponse();
        createUserResponse.id = appUser.Id;

        return ResponseHelper<AdminCreateUserResponse>.Success(createUserResponse);
    }
    public async Task<IResponse<EmptyResponse>> ConfirmEmailAsync(Guid userId, string token)
    {
        var isUserEmpty = userId == Guid.Empty;
        if (isUserEmpty) return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = nameof(AppUser.Id), errorMessage = ResourceLocalizer.UserIdIsEmpty });

        var user = await unitOfWork.userRepository.FindById(userId.ToString());
        if (user == null) return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = nameof(AppUser.Id), errorMessage = ResourceLocalizer.UserNotFound });

        var response = await unitOfWork.userRepository.ConfirmEmailAsync(user, token);
        if (!response.Succeeded) return ResponseHelper<EmptyResponse>.Failed(response.Errors.GetResponseErrors());

        return ResponseHelper<EmptyResponse>.Success();
    }
    public async Task<IResponse<string>> GenerateConfirmationToken(Guid userId)
    {
        if (userId == Guid.Empty) return ResponseHelper<string>.Failed(new Error { errorKey = nameof(AppUser.Id), errorMessage = ResourceLocalizer.UserIdIsEmpty });

        var user = await unitOfWork.userRepository.FindById(userId.ToString());
        if (user == null) return ResponseHelper<string>.Failed(new Error { errorKey = nameof(AppUser.Id), errorMessage = ResourceLocalizer.UserNotFound });

        var token =  await  unitOfWork.userRepository.GenerateConfirmationToken(user);

        return ResponseHelper<string>.Success(token);
    }
}
