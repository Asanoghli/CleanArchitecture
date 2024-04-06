using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repositories;
public interface IPagesRepository
{
    Page GetbySlug(string slug);
    Task<Guid> CreatePage(Page page);
}
