using MediatR;
using Tomi.Application.ApiResponse;

namespace Tomi.Application.Features.ShoppingCarts.Commands.RemoveAllItem
{
    public class ClearShoppingCartCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
    }
}
