using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.ShoppingCarts.Commands;

namespace Tomi.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingCartController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

		[HttpPost("add-item-to-shopping-cart")]
		public async Task<IActionResult> AddItemToShoppingCart(AddItemToShoppingCartCommand command)
		{
			return Ok(await Mediator.Send(command));
		}
	}
	}
