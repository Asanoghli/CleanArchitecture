using CleanArchitecture.Application.Contracts.Auth.Requests;

namespace CleanArchitecture.Application.Interfaces.Services;

public interface IAuthService
{
    Task Login(LoginRequest request);
    Task SignOut();
}
