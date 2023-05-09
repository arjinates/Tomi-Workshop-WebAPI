using Tomi.Domain.Entities;

namespace Tomi.Domain.IRepositories
{
    public interface ICouponRepository : IBaseRepository<Coupon>
    {
        Task<Coupon> GetByCouponIdAsync(string id);
    }
}
