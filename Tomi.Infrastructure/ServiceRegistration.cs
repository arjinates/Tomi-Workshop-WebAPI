using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tomi.Domain.IRepositories;
using Tomi.Infrastructure.Contexts;
using Tomi.Infrastructure.Repositories;

namespace Tomi.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
		{
			
			#region LifeTime
			services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
			services.AddTransient(typeof(IMongoContext), typeof(MongoContext));
			#endregion

		}
	}
}
