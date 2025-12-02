using System.Security.Claims;
using Classes.Dtos;
using Classes.Features.Auth.Commands.ChangePassword;
using Classes.Features.Auth.Commands.Login;
using Classes.Features.Users.Commands;
using Classes.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Classes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<UserDTO> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken);

        [HttpPost("Login")]
        public async Task<string> Login([FromBody] LoginCommand command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken);

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<bool> ChangePassword([FromBody] ChangePasswordCommand command, CancellationToken cancellationToken) =>
            await _mediator.Send(command, cancellationToken);

        [HttpGet("IsOk")]
        public async Task<OkResult> IsOk() => Ok();

        // [Authorize]
        // [HttpGet("profile")]
        // public async Task<UserDTO> GetProfile(CancellationToken cancellationToken)
        // {
        //     var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        //     return await _mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
        // }
    }
}