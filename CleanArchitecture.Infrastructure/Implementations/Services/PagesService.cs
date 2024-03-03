using CleanArchitecture.Application.Contracts.Page.Requests;
using CleanArchitecture.Application.Contracts.Page.Response;
using CleanArchitecture.Application.Interfaces.Responses;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Implementations.Response;
using CleanArchitecture.Infrastructure.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Infrastructure.Implementations.Services;
public class PagesService : IPagesService
{
    private readonly IUnitOfWork unitOfWork;
    public PagesService(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }
    public IResponse<GetPageBySlugModel> GetBySlug(string slug)
    {
        return ResponseHelper<GetPageBySlugModel>.Success(null);
    }

    public async Task<IResponse<CreatePageResponseModel>> CreatePage(CreatePageRequestModel page)
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

        return ResponseHelper<CreatePageResponseModel>.Success(new CreatePageResponseModel { id=newPag.Id});
    }
}
