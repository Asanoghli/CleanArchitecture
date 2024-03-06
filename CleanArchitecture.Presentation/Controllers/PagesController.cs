using CleanArchitecture.Application.Contracts.Page.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
[ApiController]
[Route("pages")]
public class PagesController : ControllerBase
{
    private readonly IPageService pagesService;
    public PagesController(IPageService _pagesService)
    {
        pagesService = _pagesService;   
    }
    [HttpGet("new")]
    public async Task<IActionResult> CreatePage( )
    {
        var response = await pagesService.CreatePage(new CreatePageRequestModel
        {
            title = "გვერდი 5",
            titleEng = "page 5",
             description ="აღწერა 5",
             descriptionEng = "Description 5",
              slug = "გვერდი-5",
              slugEng = "page-5"
        });
        return Ok(response);
    }
}
