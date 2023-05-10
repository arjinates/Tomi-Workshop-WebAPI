using MediatR;
using Tomi.Application.ApiResponse;

namespace Tomi.Application.Features.ShoppingCarts.Commands
{
    public class RemoveItemCompeletelyCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
}
