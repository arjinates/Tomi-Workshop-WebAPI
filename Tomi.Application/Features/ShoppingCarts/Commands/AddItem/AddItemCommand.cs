using MediatR;
using Tomi.Application.Models;

namespace Tomi.Application.Features.ShoppingCarts.Commands.AddItem
{
    public class AddItemCommand : IRequest<ShoppingCartItemModel>
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
}
