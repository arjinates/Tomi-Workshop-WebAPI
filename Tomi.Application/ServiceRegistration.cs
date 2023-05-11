using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tomi.Application.Auth.Commands;
using Tomi.Application.Features.Coupons.Commands.Apply;
using Tomi.Application.Features.Coupons.Queries.GetAll;
using Tomi.Application.Features.Products.Queries.GetAll;
using Tomi.Application.Features.Products.Queries.GetById;
using Tomi.Application.Features.ShoppingCarts.Commands.AddItem;
using Tomi.Application.Features.ShoppingCarts.Commands.RemoveAllItem;
using Tomi.Application.Features.ShoppingCarts.Queries.GetAll;
using Tomi.Application.Mappings;

namespace Tomi.Application
{
    public static class ServiceRegistration
	{
		public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(typeof(GeneralProfile).Assembly);

			services.AddMediatR(typeof(GetAllProductsHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(GetProductByIdHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(AuthenticateCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(RegisterCommandHandler).GetTypeInfo().Assembly);

			services.AddMediatR(typeof(AddItemToShoppingCartHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ClearShoppingCartHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(GetAllShoppingCartItemsByUserIdHandler).GetTypeInfo().Assembly);

			services.AddMediatR(typeof(ApplyCouponHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(GetAllCouponsHandler).GetTypeInfo().Assembly);
			#region Repositories

			#endregion
		}
	}
}
