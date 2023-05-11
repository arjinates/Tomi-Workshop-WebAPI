using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Application.Features.ShoppingCarts.Commands.AddItem;
using Tomi.Application.Features.ShoppingCarts.Commands.RemoveAllItem;
using Tomi.Application.Features.ShoppingCarts.Commands.RemoveItem;
using Tomi.Application.Features.ShoppingCarts.Commands.RemoveItemByQuantity;
using Tomi.Application.Features.ShoppingCarts.Queries;
using Tomi.Application.Features.ShoppingCarts.Queries.GetAll;
using Tomi.Domain.Entities;

namespace Tomi.WebAPI.Controllers
{
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

        [HttpDelete("decrease-item-amount-in-shopping-cart")]
        public async Task<IActionResult> RemoveItemFromShoppingCart(string productId)
        {
			var command = new RemoveItemCommand();
			command.UserId = UserId;
			command.ProductId= productId;
			return Ok(await Mediator.Send(command));
		}


		[HttpDelete("remove-item-by-quantity")]
		public async Task<IActionResult> RemoveItemByQuantityFromShoppingCart(string productId, int quantity)
		{
			var command = new RemoveItemByQuantityCommand();
			command.UserId = UserId;
			command.ProductId = productId;
			command.Quantity = quantity;
			return Ok(await Mediator.Send(command));
		}


		[HttpDelete("clear-shopping-cart")]
        public async Task<IActionResult> ClearShoppingCart()
        {
			var command = new ClearShoppingCartCommand();
			command.UserId = UserId;
			return Ok(await Mediator.Send(command));
        }

    }
	}
