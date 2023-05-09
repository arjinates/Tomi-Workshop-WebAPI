using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Application.Features.ShoppingCarts.Queries;

namespace Tomi.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingCartController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

		[HttpGet("get-all-shopping-cart-items")]
		public async Task<IActionResult> GetAllShoppingCartItemsByUserId([FromQuery] GetAllShoppingCartItemsByUserIdQuery command)
		{
			return Ok(await Mediator.Send(command));
		}

		[HttpPost("add-item-to-shopping-cart")]
		public async Task<IActionResult> AddItemToShoppingCart(AddItemCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

        [HttpDelete("remove-item-from-shopping-cart")]
        public async Task<IActionResult> RemoveItemToShoppingCart(RemoveItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("remove-all-items-from-shopping-cart")]
        public async Task<IActionResult> RemoveAllItemsFromShoppingCart(RemoveAllItemsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
	}
