using AutoMapper;
using MediatR;
using Tomi.Application.ApiResponse;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Domain.IRepositories;

namespace Tomi.Application.Services.Handlers.ShoppingCarts
{
    public class RemoveAllItemsFromShoppingCart : IRequestHandler<RemoveAllItemsCommand, Response<string>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public RemoveAllItemsFromShoppingCart(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<Response<string>> Handle(RemoveAllItemsCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetByUserIdAsync(request.UserId);

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart not found.");
            }

            shoppingCart.ShoppingCartItemList.Clear();
            shoppingCart.CouponId = null;

            await _shoppingCartRepository.DeleteAsync(shoppingCart.Id);
           
            return new Response<string>(request.UserId, $"ShoppingCart successfully deleted."); 
        }
    }
}
