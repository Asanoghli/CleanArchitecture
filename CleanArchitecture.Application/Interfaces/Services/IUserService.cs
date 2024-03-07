using CleanArchitecture.Application.Contracts.Admin.Users.Requests;
using CleanArchitecture.Application.Contracts.Admin.Users.Responses;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Application.Interfaces.Services;

public interface IUserService
{
    Task<IResponse<AdminCreateUserResponse>> CreateUserAsync(AdminCreateUserRequest user);
    Task<IResponse<EmptyResponse>> ConfirmEmailAsync(Guid userId, string token);
    Task<IResponse<string>> GenerateConfirmationToken(Guid userId);
}
