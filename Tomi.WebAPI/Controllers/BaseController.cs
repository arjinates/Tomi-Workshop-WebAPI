using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Tomi.WebAPI.Controllers
{
	[ApiController]
	public class BaseController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
		protected string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
