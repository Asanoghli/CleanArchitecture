using CleanArchitecture.Application.Contracts.User.Requests;

namespace CleanArchitecture.Application.Interfaces.Services;

public interface IUserService
{
    Task<Guid> CreateUserAsync(CreateUserRequest user);
}
