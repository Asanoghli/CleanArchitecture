﻿using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Common.Enums;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;
using CleanArchitecture.Infrastructure.Resources;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Implementations.Services;

public class AuthService(IUnitOfWork unitOfWork) : IAuthService
{
    public async Task<IResponse<EmptyResponse>> ConfirmEmail(string token, Guid userId)
    {
        var culture = Thread.CurrentThread.CurrentCulture;
        var culture2 = CultureInfo.CurrentCulture;
        if (userId == Guid.Empty)
        return ResponseHelper<EmptyResponse>.Failed(new Error { errorKey = ErrorCodes.USER_NOT_FOUND, errorMessage = ResourceLocalizer.UserNotFound});
        var user = await unitOfWork.authRepository.FindById(userId.ToString());

        return null;
    }

    public async Task Login(LoginRequest request)
    {
        var user = await unitOfWork.authRepository.FindByUsername(request.username);
        if (user is null) { }


        var result = await unitOfWork.authRepository.LoginWithPassword(user, request.password, request.rememberMe);
    }

    public async Task SignOut()
    {
        await unitOfWork.authRepository.SignOutAsync();
    }
}
