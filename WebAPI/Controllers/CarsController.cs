using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetAll;
using Application.Features.Cars.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCarsQuery getAllCarsQuery = new();

            var response = await Mediator.Send(getAllCarsQuery);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdCarQuery getByIdCarQuery = new()
            {
                Id = id
            };

            var response = await Mediator.Send(getByIdCarQuery);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateCarCommand)
        {
            UpdatedCarResponse? result = await Mediator.Send(updateCarCommand);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteCarCommand deleteCarCommand = new()
            {
                Id = id
            };

            DeletedCarResponse? result = await Mediator.Send(deleteCarCommand);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
        {
            CreatedCarResponse? result = await Mediator.Send(createCarCommand);

            return Created("", result);
        }
    }
}
