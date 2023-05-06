using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;
using Tomi.Infrastructure.Contexts;

namespace Tomi.Infrastructure.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(IMongoContext mongoContext, string collectionName) : base(mongoContext, collectionName)
		{
		}
	}
}
