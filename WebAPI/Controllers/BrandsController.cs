using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BrandsController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllBrandsQuery getAllBrandsQuery = new();

        var response = await Mediator.Send(getAllBrandsQuery);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBrandQuery getByIdBrandQuery = new()
        {
            Id = id
        };

        var response = await Mediator.Send(getByIdBrandQuery);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandResponse? response = await Mediator.Send(updateBrandCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteBrandCommand deleteBrandCommand = new()
        {
            Id = id
        };

        DeletedBrandResponse? response = await Mediator.Send(deleteBrandCommand);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        // TODO: Controller seviyesindeki Authentication yapısını dinamik olacak bir biçimde
        // Application katmanı seviyesine çek.

        var user = _httpContextAccessor.HttpContext.User;

        if (!user.Identity.IsAuthenticated)
            throw new Exception("Giriş yapmadan bu endpointi çalıştıramazsınız.");

        CreatedBrandResponse? response = await Mediator.Send(createBrandCommand);

        return Created("", response);
    }
}
