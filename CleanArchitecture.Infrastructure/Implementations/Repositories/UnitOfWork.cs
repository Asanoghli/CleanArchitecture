using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Identity.Implementations.Repositories;
using CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories
{
    public class UnitOfWork(CleanArchitectureDbContext dbContext,SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : IUnitOfWork
    {

        private IDbContextTransaction _transaction;
        private IPagesRepository _pagesRepository;
        private IUserRepository _userRepository;
        private IAuthRepository _authRepository;

        public IPagesRepository pagesRepository
        {
            get
            {
                if (_pagesRepository == null) _pagesRepository = new PagesRepository(dbContext);

                return _pagesRepository;
            }
        }
        public IUserRepository userRepository
        {
            get
            {
                if (_userRepository == null) _userRepository = new UserRepository(userManager);

                return _userRepository;
            }
        }
        public IAuthRepository authRepository
        {

            get
            {
                if (_authRepository == null) _authRepository = new AuthRepository(signInManager, userManager);

                return _authRepository;
            }
        }

        public async Task BeginTransactin(CancellationToken cancellationToken)
        {
            _transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransaction(CancellationToken token)
        {
            await _transaction.CommitAsync(token);
        }

        public async Task RollBackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
