using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Auth.Models;
using Tomi.Application.Features.Products.Queries;

namespace Tomi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticateRequest command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register( RegisterRequest command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
