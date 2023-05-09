using MediatR;

namespace Tomi.Application.Features.Coupons.Commands
{
    public class ApplyCouponCommand : IRequest<CouponModel>
    {
        public string UserId { get; set; }
        public string CouponId { get; set; }
    }
}
