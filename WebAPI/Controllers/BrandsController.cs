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
        UpdatedBrandResponse? result = await Mediator.Send(updateBrandCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteBrandCommand deleteBrandCommand = new()
        {
            Id = id
        };

        DeletedBrandResponse? result = await Mediator.Send(deleteBrandCommand);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        CreatedBrandResponse? result = await Mediator.Send(createBrandCommand);

        return Created("", result);
    }
}
