using CleanArchitecture.Application.Contracts.Admin.Page.Requests;
using CleanArchitecture.Application.Contracts.Admin.Page.Response;
using CleanArchitecture.Common.Interfaces.Responses;

namespace CleanArchitecture.Application.Interfaces.Services;
public interface IPageService
{
    IResponse<AdminGetPageBySlugModel> GetBySlug(string slug);
    Task<IResponse<AdminCreatePageResponseModel>> CreatePage(AdminCreatePageRequestModel page);
}
