using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;
using Tomi.Infrastructure.Contexts;
using Tomi.Infrastructure.Settings;

namespace Tomi.Infrastructure.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
	{
		public ShoppingCartRepository(IMongoContext mongoContext, IOptions<MongoDbSettings> mongoDbSettings) : base(mongoContext, mongoDbSettings)
		{
		}
		public async Task<ShoppingCart> GetByUserIdAsync(string id)
		{
			return await _collection.Find(x => x.UserId == id).FirstOrDefaultAsync();
		}
	}
}
