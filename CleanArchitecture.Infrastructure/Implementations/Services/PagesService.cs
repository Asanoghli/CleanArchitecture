using CleanArchitecture.Application.Contracts.Admin.Page.Requests;
using CleanArchitecture.Application.Contracts.Admin.Page.Response;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Common.Implementations.Response;
using CleanArchitecture.Common.Interfaces.Responses;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Implementations.Services;
public class PagesService : IPageService
{
    private readonly IUnitOfWork unitOfWork;
    public PagesService(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    public IResponse<AdminGetPageBySlugModel> GetBySlug(string slug)
    {
        return ResponseHelper<AdminGetPageBySlugModel>.Success(null);
    }

    public async Task<IResponse<AdminCreatePageResponseModel>> CreatePage(AdminCreatePageRequestModel page)
    {
        var newPag = new Page
        {
            Title = page.title,
            TitleEng = page.titleEng,
            Description = page.description,
            DescriptionEng = page.descriptionEng,
            Slug = page.slug,
            SlugEng = page.slugEng,
        };
        await unitOfWork.pagesRepository.CreatePage(newPag);

        return ResponseHelper<AdminCreatePageResponseModel>.Success(new AdminCreatePageResponseModel { id=newPag.Id});
    }
}
