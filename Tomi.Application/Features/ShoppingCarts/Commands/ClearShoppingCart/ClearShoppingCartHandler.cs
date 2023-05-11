using AutoMapper;
using MediatR;
using Tomi.Application.ApiResponse;
using Tomi.Domain.IRepositories;

namespace Tomi.Application.Features.ShoppingCarts.Commands.RemoveAllItem
{
    public class ClearShoppingCartHandler : IRequestHandler<ClearShoppingCartCommand, Response<string>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ClearShoppingCartHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<Response<string>> Handle(ClearShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetByUserIdAsync(request.UserId);

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart not found.");
            }

            shoppingCart.ShoppingCartItemList.Clear();
            shoppingCart.CouponId = null;

            await _shoppingCartRepository.DeleteAsync(shoppingCart.Id);

            return new Response<string>(request.UserId, true, $"ShoppingCart successfully deleted.");
        }
    }
}
