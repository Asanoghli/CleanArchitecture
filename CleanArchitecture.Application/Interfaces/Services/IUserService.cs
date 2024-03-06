using CleanArchitecture.Application.Contracts.User.Requests;
using CleanArchitecture.Application.Contracts.User.Responses;
using CleanArchitecture.Application.Interfaces.Responses;

namespace CleanArchitecture.Application.Interfaces.Services;

public interface IUserService
{
    Task<IResponse<CreateUserResponse>> CreateUserAsync(CreateUserRequest user);
}
