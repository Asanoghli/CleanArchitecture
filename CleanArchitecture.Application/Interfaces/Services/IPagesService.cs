using CleanArchitecture.Application.Contracts.Page.Requests;
using CleanArchitecture.Application.Contracts.Page.Response;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Responses;

namespace CleanArchitecture.Application.Interfaces.Services;
public interface IPagesService
{
    IResponse<GetPageBySlugModel> GetBySlug(string slug);
    Task<IResponse<CreatePageResponseModel>> CreatePage(CreatePageRequestModel page);
}
