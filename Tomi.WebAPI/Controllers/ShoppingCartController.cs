using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Application.Features.ShoppingCarts.Queries;
using Tomi.Domain.Entities;

namespace Tomi.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ShoppingCartController : BaseController
	{

		[HttpGet("get-all-shopping-cart-items")]
		public async Task<IActionResult> GetAllShoppingCartItemsByUserId()
		{
			var command = new GetAllShoppingCartItemsByUserIdQuery();
			command.UserId = UserId;
			return Ok(await Mediator.Send(command));
		}

		[HttpPost("add-item-to-shopping-cart")]
		public async Task<IActionResult> AddItemToShoppingCart(string productId)
		{
			var command = new AddItemCommand();
			command.UserId = UserId;
			command.ProductId = productId;
			return Ok(await Mediator.Send(command));
		}

        [HttpDelete("remove-item-from-shopping-cart")]
        public async Task<IActionResult> RemoveItemFromShoppingCart(string productId)
        {
			var command = new RemoveItemCommand();
			command.UserId = UserId;
			command.ProductId= productId;
			return Ok(await Mediator.Send(command));
		}

        [HttpDelete("remove-all-items-from-shopping-cart")]
        public async Task<IActionResult> RemoveAllItemsFromShoppingCart()
        {
			var command = new RemoveAllItemsCommand();
			command.UserId = UserId;
			return Ok(await Mediator.Send(command));
        }
        [HttpDelete("remove-item-from-shopping-cart-compeletely")]
        public async Task<IActionResult> RemoveItemFromShoppingCartCompeletely(string productId)
        {
            var command = new RemoveItemCompeletelyCommand();
            command.UserId = UserId;
            command.ProductId = productId;
            return Ok(await Mediator.Send(command));
        }
    }
	}
