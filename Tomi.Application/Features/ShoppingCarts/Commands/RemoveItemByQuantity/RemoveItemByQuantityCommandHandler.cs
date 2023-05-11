using AutoMapper;
using MediatR;
using Tomi.Application.ApiResponse;
using Tomi.Application.Auth.Models;
using Tomi.Application.Models;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace Tomi.Application.Features.ShoppingCarts.Commands.RemoveItemByQuantity
{
	public class RemoveItemByQuantityCommandHandler : IRequestHandler<RemoveItemByQuantityCommand, Response<string>>
	{
		private readonly IShoppingCartRepository _shoppingCartRepository;
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public RemoveItemByQuantityCommandHandler(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, IMapper mapper)
		{
			_shoppingCartRepository = shoppingCartRepository;
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<Response<string>> Handle(RemoveItemByQuantityCommand request, CancellationToken cancellationToken)
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

			if (request.Quantity >= existingCartItem.Count)
			{
				shoppingCart.ShoppingCartItemList.Remove(existingCartItem);
			}
			else
			{
				existingCartItem.Count -= request.Quantity;
			}

			if (shoppingCart.ShoppingCartItemList.Count == 0)
			{
				await _shoppingCartRepository.DeleteAsync(shoppingCart.Id);
				return null;
			}
			else
			{
				await _shoppingCartRepository.UpdateAsync(shoppingCart.Id, shoppingCart);
				return new Response<string>(true, message:$"{request.Quantity} item removed");
			}
		}

	}
}