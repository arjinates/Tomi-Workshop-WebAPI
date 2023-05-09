using MediatR;

namespace Tomi.Application.Features.ShoppingCarts.Commands
{
    public class AddItemToShoppingCartCommand : IRequest<ShoppingCartItemModel>
	{
		public string UserId { get; set; }
		public string ProductId { get; set; }
	}
}
