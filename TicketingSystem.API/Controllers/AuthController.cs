using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.API.RequestDTOs.AuthDTOs;
using TicketingSystem.Application.UserCommandandQueries.Logins;
using TicketingSystem.Application.UserCommandandQueries.RegisterCommands;

namespace TicketingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _mediator.Send(new RegisterCommand(registerDto.FirstName,
                                                                  registerDto.LastName,
                                                                  registerDto.Email,
                                                                  registerDto.Password,
                                                                  registerDto.UserRole));
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _mediator.Send(new LoginCommand(loginDto.Username,
                                                               loginDto.Password));
            return Ok(result);
        }

    }
}
