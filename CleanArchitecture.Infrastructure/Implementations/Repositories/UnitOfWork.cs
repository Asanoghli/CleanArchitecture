using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories
{
    public class UnitOfWork(CleanArchitectureDbContext dbContext) : IUnitOfWork
    {

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
                //if (_userRepository == null) _userRepository = new UserRepository(userManager);

                return _userRepository;
            }
        }

        public IAuthRepository authRepository
        {

            get
            {
                //if (_authRepository == null) _authRepository = new AuthRepository(signInManager, userManager);

                return _authRepository;
            }
        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
