using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Auth.Models;

namespace Tomi.WebAPI.Controllers
{
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
