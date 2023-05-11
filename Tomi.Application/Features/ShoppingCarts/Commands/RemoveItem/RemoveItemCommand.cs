using MediatR;
using Tomi.Application.ApiResponse;
using Tomi.Application.Models;

namespace Tomi.Application.Features.ShoppingCarts.Commands.RemoveItem
{
    public class RemoveItemCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
}
