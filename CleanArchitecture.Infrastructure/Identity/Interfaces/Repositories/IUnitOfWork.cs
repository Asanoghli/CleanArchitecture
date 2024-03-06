using CleanArchitecture.Application.Interfaces.Repositories;

namespace CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IPagesRepository pagesRepository { get; }
        IUserRepository userRepository { get; }
        IAuthRepository authRepository { get; }
        Task BeginTransactin(CancellationToken cancellation);
        Task CommitTransaction(CancellationToken cancellation);
        Task RollBackTransaction(CancellationToken cancellation);
        Task SaveChangesAsync(CancellationToken cancellation);
    }
}
