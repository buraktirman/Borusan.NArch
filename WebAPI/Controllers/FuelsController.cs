using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetAll;
using Application.Features.Fuels.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllFuelsQuery getAllFuelsQuery = new();

        var response = await Mediator.Send(getAllFuelsQuery);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdFuelQuery getByIdFuelQuery = new()
        {
            Id = id
        };

        var response = await Mediator.Send(getByIdFuelQuery);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFuelCommand updateFuelCommand)
    {
        UpdatedFuelResponse? result = await Mediator.Send(updateFuelCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteFuelCommand deleteFuelCommand = new()
        {
            Id = id
        };

        DeletedFuelResponse? result = await Mediator.Send(deleteFuelCommand);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
    {
        CreatedFuelResponse? result = await Mediator.Send(createFuelCommand);

        return Created("", result);
    }
}
