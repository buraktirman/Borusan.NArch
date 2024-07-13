using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries.GetAll;
using Application.Features.Transmissions.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllTransmissionsQuery getAllTransmissionsQuery = new();

        var response = await Mediator.Send(getAllTransmissionsQuery);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTransmissionQuery getByIdTransmissionQuery = new()
        {
            Id = id
        };

        var response = await Mediator.Send(getByIdTransmissionQuery);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTransmissionCommand updateTransmissionCommand)
    {
        UpdatedTransmissionResponse? result = await Mediator.Send(updateTransmissionCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteTransmissionCommand deleteTransmissionCommand = new()
        {
            Id = id
        };

        DeletedTransmissionResponse? result = await Mediator.Send(deleteTransmissionCommand);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionCommand)
    {
        CreatedTransmissionResponse? result = await Mediator.Send(createTransmissionCommand);

        return Created("", result);
    }
}
