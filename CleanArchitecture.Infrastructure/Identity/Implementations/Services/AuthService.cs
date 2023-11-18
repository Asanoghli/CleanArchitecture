using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Identity.Interfaces.Services;

namespace CleanArchitecture.Infrastructure.Identity.Implementations.Services;

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public async Task Login(LoginRequest request)
    {
        var user = await authRepository.FindByUsername(request.username);
        if (user is null) { }


        var result = await authRepository.LoginWithPassword(user, request.password, request.rememberMe);
    }

    public async Task SignOut()
    {
        await authRepository.SignOutAsync();
    }
}
