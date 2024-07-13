using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries.GetAll;
using Application.Features.Colors.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllColorsQuery getAllColorsQuery = new();

        var response = await Mediator.Send(getAllColorsQuery);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdColorQuery getByIdColorQuery = new()
        {
            Id = id
        };

        var response = await Mediator.Send(getByIdColorQuery);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColorCommand)
    {
        UpdatedColorResponse? result = await Mediator.Send(updateColorCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteColorCommand deleteColorCommand = new()
        {
            Id = id
        };

        DeletedColorResponse? result = await Mediator.Send(deleteColorCommand);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
    {
        CreatedColorResponse? result = await Mediator.Send(createColorCommand);

        return Created("", result);
    }
}
