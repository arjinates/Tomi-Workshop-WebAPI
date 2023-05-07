using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Auth.Models;
using Tomi.Application.Features.Products.Queries;

namespace Tomi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] AuthenticateRequest command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromQuery] RegisterRequest command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
