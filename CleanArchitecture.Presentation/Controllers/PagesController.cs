using CleanArchitecture.Application.Contracts.Page.Requests;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Infrastructure.Identity.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
[ApiController]
[Route("pages")]
public class PagesController : ControllerBase
{
    private readonly IPagesService pagesService;
    public PagesController(IPagesService _pagesService)
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
