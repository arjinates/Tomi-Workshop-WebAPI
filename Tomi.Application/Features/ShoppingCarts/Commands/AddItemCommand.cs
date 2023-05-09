using MediatR;

namespace Tomi.Application.Features.ShoppingCarts.Commands
{
    public class AddItemCommand : IRequest<ShoppingCartItemModel>
	{
		public string UserId { get; set; }
		public string ProductId { get; set; }
	}
}
