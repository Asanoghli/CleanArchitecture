using CleanArchitecture.Application.Contracts.Page.Requests;
using CleanArchitecture.Application.Contracts.Page.Response;
using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Application.Interfaces.Services;
public interface IPageService
{
    IResponse<GetPageBySlugModel> GetBySlug(string slug);
    Task<IResponse<CreatePageResponseModel>> CreatePage(CreatePageRequestModel page);
}
