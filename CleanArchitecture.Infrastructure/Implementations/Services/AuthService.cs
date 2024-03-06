using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;

namespace CleanArchitecture.Infrastructure.Implementations.Services;

public class AuthService(IUnitOfWork UnitOfWork) : IAuthService
{
    public async Task Login(LoginRequest request)
    {
        var user = await UnitOfWork.authRepository.FindByUsername(request.username);
        if (user is null) { }


        var result = await UnitOfWork.authRepository.LoginWithPassword(user, request.password, request.rememberMe);
    }

    public async Task SignOut()
    {
        await UnitOfWork.authRepository.SignOutAsync();
    }
}
