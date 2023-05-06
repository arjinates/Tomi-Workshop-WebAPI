using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			services.AddTransient<IProductRepository>(serviceProvider =>
				new ProductRepository(serviceProvider.GetRequiredService<IMongoContext>(), "Product"));
			services.AddTransient(typeof(IMongoContext), typeof(MongoContext));
			#endregion
		}
	}
}
