using MediatR;
using Tomi.Application.ApiResponse;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Application.Models;
using Tomi.Domain.IRepositories;

namespace Tomi.Application.Services.Handlers.ShoppingCarts
{
    public class RemoveItemFromShoppingCartCompeletely : IRequestHandler<RemoveItemCompeletelyCommand, Response<string>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public RemoveItemFromShoppingCartCompeletely(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public async Task<Response<string>> Handle(RemoveItemCompeletelyCommand request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetByUserIdAsync(request.UserId);
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (shoppingCart == null)
            {
                throw new InvalidOperationException("Shopping cart not found.");
            }

            var existingCartItem = shoppingCart.ShoppingCartItemList.FirstOrDefault(item => item.ItemId == product.Id);

            if (existingCartItem == null)
            {
                throw new InvalidOperationException("Product not found in shopping cart.");
            }

            shoppingCart.ShoppingCartItemList.Remove(existingCartItem);


            if (shoppingCart.ShoppingCartItemList.Count == 0)
            {
                await _shoppingCartRepository.DeleteAsync(shoppingCart.Id);
            }
            else
            {
                await _shoppingCartRepository.UpdateAsync(shoppingCart.Id, shoppingCart);
            }

            return new Response<string>(request.UserId, $"Item successfully removed from shopping cart.");
        }
    }
}

