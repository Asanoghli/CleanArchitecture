using CleanArchitecture.Application.Contracts.Auth.Requests;

namespace CleanArchitecture.Infrastructure.Identity.Interfaces.Services;

public interface IAuthService
{
    Task Login(LoginRequest request);
    Task SignOut();
}
