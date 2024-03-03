using CleanArchitecture.Application.Interfaces.Repositories;

namespace CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IPagesRepository pagesRepository { get; }
        IUserRepository userRepository { get; }
        IAuthRepository authRepository { get; }
        Task Save();
    }
}
