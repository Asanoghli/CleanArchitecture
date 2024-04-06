using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Context;

namespace CleanArchitecture.Infrastructure.Implementations.Repositories
{
    public class PagesRepository(CleanArchitectureDbContext dbContext):IPagesRepository
    {
        public async Task<Guid> CreatePage(Page page)
        {
            await dbContext.Pages.AddAsync(page);

            await dbContext.SaveChangesAsync();

            return page.Id;
        }

        public Page GetbySlug(string slug)
        {
            return null;
        }
    }
}
