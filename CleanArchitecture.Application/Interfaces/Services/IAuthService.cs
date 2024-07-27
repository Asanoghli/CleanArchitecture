using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Application.Contracts.Auth.Responses;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Application.Interfaces.Services;

public interface IAuthService
{
    Task<IResponse<AdminAuthLoginResponse>> Login(LoginRequest request);
    Task SignOut();
    Task<IResponse<EmptyResponse>> ConfirmEmail(string token, Guid userId);
    public Task<bool> ValidateToken(string token);
}