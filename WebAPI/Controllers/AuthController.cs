using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
    {
        var response = await Mediator.Send(registerCommand);
        return Created("", response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
    {
        var response = await Mediator.Send(loginCommand);
        return Ok(response);
    }
}
