using Microsoft.Extensions.Options;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;
using Tomi.Infrastructure.Contexts;
using Tomi.Infrastructure.Settings;

namespace Tomi.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(IMongoContext mongoContext, IOptions<MongoDbSettings> mongoDbSettings) : base(mongoContext, mongoDbSettings)
		{
		}
	}
}
