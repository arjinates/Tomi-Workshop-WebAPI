using AutoMapper;
using MediatR;
using Tomi.Application.Features.ShoppingCarts.Queries;
using Tomi.Application.Models;
using Tomi.Domain.IRepositories;

namespace Tomi.Application.Services.Handlers.ShoppingCarts
{
	public class GetAllShoppingCartItems : IRequestHandler<GetAllShoppingCartItemsByUserIdQuery, ShoppingCartModel>
	{
		private readonly IShoppingCartRepository _shoppingCartRepository;
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public GetAllShoppingCartItems(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, IMapper mapper)
		{
			_shoppingCartRepository = shoppingCartRepository;
			_productRepository = productRepository;
			_mapper = mapper;
		}
		public async Task<ShoppingCartModel> Handle(GetAllShoppingCartItemsByUserIdQuery request, CancellationToken cancellationToken)
		{
			var shoppingCart = await _shoppingCartRepository.GetByUserIdAsync(request.UserId);
			if (shoppingCart == null)
			{
				throw new InvalidOperationException("Shopping cart not found.");
			}

			var itemListModel = new ShoppingCartModel
			{
				Items = new List<ShoppingCartItemModel>(),
				TotalShoppingCart = 0,
			};

			decimal totalPrice = 0;

			foreach (var item in shoppingCart.ShoppingCartItemList)
			{
				var product = await _productRepository.GetByIdAsync(item.ItemId);
				var itemTotalPrice = product.Price * item.Count;

				totalPrice += itemTotalPrice;

				itemListModel.Items.Add(new ShoppingCartItemModel
				{
					UserId = request.UserId,
					ProductId = product.Id,
					ProductTotalPrice = itemTotalPrice,	
					ProductCount= item.Count
				});
			}

			itemListModel.TotalShoppingCart = totalPrice;

			return itemListModel;
		}
	}
}


