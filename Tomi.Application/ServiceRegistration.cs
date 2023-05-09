using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tomi.Application.Auth.Commands;
using Tomi.Application.Mappings;
using Tomi.Application.Services.Handlers.Coupons;
using Tomi.Application.Services.Handlers.Products;
using Tomi.Application.Services.Handlers.ShoppingCarts;

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

			services.AddMediatR(typeof(AddItemToShoppingCart).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(RemoveAllItemsFromShoppingCart).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(GetAllShoppingCartItems).GetTypeInfo().Assembly);

			services.AddMediatR(typeof(ApplyCouponHandler).GetTypeInfo().Assembly);
			#region Repositories

			#endregion
		}
	}
}
