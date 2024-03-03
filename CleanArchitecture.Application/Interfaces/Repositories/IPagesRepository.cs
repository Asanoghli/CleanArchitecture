using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repositories;
public interface IPagesRepository:IGenericRepository<Page>
{
    Page GetbySlug(string slug);
    Task<Guid> CreatePage(Page page);
}
