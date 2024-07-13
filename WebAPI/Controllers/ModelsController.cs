using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Queries.GetAll;
using Application.Features.Models.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllModelsQuery getAllModelsQuery = new();

        var response = await Mediator.Send(getAllModelsQuery);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdModelQuery getByIdModelQuery = new()
        {
            Id = id
        };

        var response = await Mediator.Send(getByIdModelQuery);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateModelCommand updateModelCommand)
    {
        UpdatedModelResponse? result = await Mediator.Send(updateModelCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteModelCommand deleteModelCommand = new()
        {
            Id = id
        };

        DeletedModelResponse? result = await Mediator.Send(deleteModelCommand);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateModelCommand createModelCommand)
    {
        CreatedModelResponse? result = await Mediator.Send(createModelCommand);

        return Created("", result);
    }
}
