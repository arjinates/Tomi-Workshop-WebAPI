using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;
using Tomi.Infrastructure.Contexts;

namespace Tomi.Infrastructure.Repositories
{
    public class CouponRepository : BaseRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(IMongoContext mongoContext, IOptions<MongoDbSettings> mongoDbSettings) : base(mongoContext, mongoDbSettings)
        {
        }

        public async Task<Coupon> GetByCouponIdAsync(string id)
        {
            return await _collection.Find(x => x.CouponId == id).FirstOrDefaultAsync();
        }
    }
}
