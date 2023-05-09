using AutoMapper;
using MediatR;
using MongoDB.Driver;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace Tomi.Application.Services.Handlers.ShoppingCarts
{
	public class AddItemToShoppingCart : IRequestHandler<AddItemCommand, ShoppingCartItemModel>
	{
		private readonly IShoppingCartRepository _shoppingCartRepository;
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public AddItemToShoppingCart(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, IMapper mapper)
		{
			_shoppingCartRepository = shoppingCartRepository;
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<ShoppingCartItemModel> Handle(AddItemCommand request, CancellationToken cancellationToken)
		{
			var shoppingCart = await _shoppingCartRepository.GetByUserIdAsync(request.UserId);
			var product = await _productRepository.GetByIdAsync(request.ProductId);

			if (shoppingCart == null)
			{
				shoppingCart = new ShoppingCart
				{
					UserId = request.UserId,
					ShoppingCartItemList = new List<ShoppingCartItem>()
				};
				await _shoppingCartRepository.CreateAsync(shoppingCart);
			}

			var existingCartItem = shoppingCart.ShoppingCartItemList.FirstOrDefault(item => item.ItemId == product.Id);

			if (existingCartItem == null)
			{
				existingCartItem = new ShoppingCartItem
				{
					ItemId = product.Id,
					Count = 0
				};
				shoppingCart.ShoppingCartItemList.Add(existingCartItem);
			}

			existingCartItem.Count += 1;
			await _shoppingCartRepository.UpdateAsync(shoppingCart.Id, shoppingCart);

			var totalPrice = product.Price * existingCartItem.Count;
			var totalCount = existingCartItem.Count;

			var response = new ShoppingCartItemModel
			{
				UserId = request.UserId,
				ProductId = product.Id,
				TotalPrice = totalPrice,
				TotalCount = totalCount
			};

			return response;
		}
	}
}
