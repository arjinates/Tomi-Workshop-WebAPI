using MediatR;
using Tomi.Application.ApiResponse;

namespace Tomi.Application.Features.ShoppingCarts.Commands
{
    public class RemoveAllItemsCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
    }
}
