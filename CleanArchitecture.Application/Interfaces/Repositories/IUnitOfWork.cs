namespace CleanArchitecture.Application.Interfaces.Repositories;
public interface IUnitOfWork:IDisposable
{
    IPagesRepository pagesRepository { get; }
    IUserRepository userRepository { get; }
    IAuthRepository authRepository { get; }
    IRolesRepository rolesRepository { get; }
    Task BeginTransactin(CancellationToken cancellation);
    Task CommitTransaction(CancellationToken cancellation);
    Task RollBackTransaction(CancellationToken cancellation);
    Task SaveChangesAsync(CancellationToken cancellation);
}

