using CleanArchitecture.Application.Contracts.Auth.Requests;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Application.Interfaces.Services;

public interface IAuthService
{
    Task Login(LoginRequest request);
    Task SignOut();
    Task<IResponse<EmptyResponse>> ConfirmEmail(string token, Guid userId);
}
