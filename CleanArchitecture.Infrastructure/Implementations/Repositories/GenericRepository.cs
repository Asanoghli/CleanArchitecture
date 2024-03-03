using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories
{
    public class GenericRepository<T>(CleanArchitectureDbContext dbContext) : IGenericRepository<T> where T : class
    {
        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task Create(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsList()
        {
           return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);

            return entity;
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    
    
    }
}
