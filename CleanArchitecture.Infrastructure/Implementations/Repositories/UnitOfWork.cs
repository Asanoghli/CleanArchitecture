using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.InteropServices;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories;
public class UnitOfWork : IUnitOfWork
{
    #region
    private CleanArchitectureDbContext _dbContext;
    private SignInManager<AppUser> _signInManager;
    private UserManager<AppUser> _userManager;
    private RoleManager<AppRole> _roleManager;
    public UnitOfWork(CleanArchitectureDbContext dbContext, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _dbContext = dbContext;
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    #endregion

    #region Private Fields

    private bool isDisposed;
    private IDbContextTransaction _transaction = default!;
    private IPagesRepository _pagesRepository = default!;
    private IUserRepository _userRepository = default!;
    private IAuthRepository _authRepository = default!;
    #endregion

    #region Public Fields
    public IPagesRepository pagesRepository
    {
        get
        {
            if (_pagesRepository == null) _pagesRepository = new PagesRepository(_dbContext);

            return _pagesRepository;
        }
    }
    public IUserRepository userRepository
    {
        get
        {
            if (_userRepository == null) _userRepository = new UserRepository(_userManager);

            return _userRepository;
        }
    }
    public IAuthRepository authRepository
    {

        get
        {
            if (_authRepository == null) _authRepository = new AuthRepository(_signInManager, _userManager,_roleManager);

            return _authRepository;
        }
    }
    #endregion

    #region Methods
    public async Task BeginTransactin(CancellationToken cancellationToken = default)
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }
    public async Task CommitTransaction(CancellationToken cancellationToken = default)
    {
        await _transaction.CommitAsync(cancellationToken);
    }
    public async Task RollBackTransaction(CancellationToken cancellationToken = default)
    {
        await _transaction.RollbackAsync(cancellationToken);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (isDisposed) return;

        if (disposing)
        {
            _authRepository = null!;
            _signInManager = null!;
            _userManager = null!;
            _pagesRepository = null!;
            _dbContext = null!;
        }

   

        isDisposed = true;
    }
    #endregion
}
